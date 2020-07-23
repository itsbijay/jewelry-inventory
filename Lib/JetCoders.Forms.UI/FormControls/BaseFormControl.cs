using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Connections;
using JetCoders.Shared;
using NLog;

namespace JetCoders.Forms.UI
{
	public class BaseFormControl : Form, IValidator
	{
		private readonly ErrorProvider baseErrorControl;
		private Dictionary<String, String> _errors { get; set; }
		private readonly List<Control> _crtl;
		protected static Logger Logger = LogManager.GetCurrentClassLogger();

		public BaseFormControl()
		{
			_errors = new Dictionary<String, String>();
			_crtl = new List<Control>();
			baseErrorControl = new ErrorProvider();
		}

		#region IValidator

		public int ErrorCount { get { return _errors.Count; } }

		public Dictionary<String, String> AllErrors { get { return _errors; } }

		public void AddValidationError(String key, String value)
		{
			_errors.Add(key, value);
		}

		public bool IsValid
		{
			get
			{
				Form form = ActiveForm;

				return _validateForm(form);
			}
		}

		/// <summary>
		/// To validate control for require field validation. set AccessibleName for that control
		/// To avoid the validation on a control Set CausesValidation to false for that control
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		protected virtual bool _validateForm(Form form)
		{
			if (form == null)
				return false;

			_errors.Clear();
			baseErrorControl.Clear();

			// Need to stop blinking of errorCrtlList control behavious
			var errorCrtlList = new List<Control>();
			_crtl.Clear();
			bool _isValid = true;

			FindInputControls(form.Controls);

			foreach (var crtl in _crtl)
			{
				if (crtl is TextBox)
				{
					var _textControl = crtl as TextBox;
                    if (_textControl.CausesValidation && _textControl.Enabled && !_textControl.ReadOnly && _textControl.Text.IsEmpty())
					{
						_isValid = false;
						AddValidationError(_textControl.Name, _textControl.AccessibleName + " is required field.");
						errorCrtlList.Add(_textControl);
					}
				}
				if (crtl is ComboBox)
				{
					var _comboControl = crtl as ComboBox;
					if (_comboControl.CausesValidation && _comboControl.SelectedIndex == -1)
					{
						_isValid = false;
						AddValidationError(_comboControl.Name, _comboControl.AccessibleName + " is required field.");
						errorCrtlList.Add(_comboControl);
					}
				}
			}

			foreach (var crtl in errorCrtlList)
			{
				baseErrorControl.SetError(crtl, crtl.AccessibleName + " is required field.");
			}

			return _isValid;
		}

		private void FindInputControls(Control.ControlCollection controls)
		{
			foreach (Control ctrl in controls)
			{
				if (ctrl is TextBox || ctrl is ComboBox || ctrl is RadioButton || ctrl is CheckBox)
				{
					if (ctrl.Enabled)
						_crtl.Add(ctrl);
				}
				FindInputControls(ctrl.Controls);
			}
		}
		#endregion
	}
}