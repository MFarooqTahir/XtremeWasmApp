﻿namespace XtremeWasmApp.Models
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
        public int? ID { get; set; }
        public string UnID { get; set; }
    }
}