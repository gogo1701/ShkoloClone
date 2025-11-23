using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    // RouterService.cs
    public class RouterService
    {
        public event Action? OnChange;

        private string _currentPage = "Home"; // default page
        public string CurrentPage
        {
            get => _currentPage;
            private set
            {
                _currentPage = value;
                OnChange?.Invoke();
            }
        }

        public void NavigateTo(string page)
        {
            CurrentPage = page;
        }
    }


}
