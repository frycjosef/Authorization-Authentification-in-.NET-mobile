using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BPMobile.ViewModels
{
	public partial class ViewModelBase : ObservableObject
	{
		[AlsoNotifyChangeFor(nameof(IsNotBusy))]
		[ObservableProperty]
		bool isBusy;

		public bool IsNotBusy => !IsBusy;
	}
}

