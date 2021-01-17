using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTL.Lib.ViewModels
{
    public class AppResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }

        public AppResult()
        {
            Errors = new List<string>();
        }

        public static AppResult Success()
        {
            return new AppResult
            {
                Succeeded = true
            };
        }

        public static AppResult Failed(string message)
        {
            var result = new AppResult
            {
                Succeeded = false
            };
            result.Errors.Add(message);
            return result;
        }

        public static AppResult Failed(IEnumerable<string> messages)
        {
            return new AppResult
            {
                Succeeded = false,
                Errors = messages.ToList()
            };
        }
    }
}
