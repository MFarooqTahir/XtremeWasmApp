﻿using System.ComponentModel.DataAnnotations;

namespace XtremeWasmApp.Models
{
	public class QRModel
	{
		public string SharedKey { get; set; }

		public string AuthenticatorUri { get; set; }

		public string[] RecoveryCodes { get; set; }

		public string StatusMessage { get; set; }

		[Required]
		[StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Text)]
		[Display(Name = "Verification Code")]
		public string Code { get; set; }
	}
}