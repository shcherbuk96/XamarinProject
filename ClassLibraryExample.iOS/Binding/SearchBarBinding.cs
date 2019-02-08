using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Foundation;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Commands;
using MvvmCross.WeakSubscription;
using UIKit;

namespace Blank.Binding
{
    class SearchBarBinding : MvxTargetBinding
    {
        private readonly UISearchBar _searchBar;
        public SearchBarBinding(UISearchBar target) : base(target)
        {
            _searchBar = target;
        }

        public override Type TargetType { get; }
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public override void SetValue(object value)
        {
            throw new NotImplementedException();
        }

        public override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            _searchBar.SearchButtonClicked += SearchClick;
        }

        private void SearchClick(object sender, EventArgs e)
        {
            if (_searchBar != null)
            {
                
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
        }
    }
}