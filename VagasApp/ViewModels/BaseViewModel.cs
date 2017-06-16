﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VagasApp.Services;

namespace VagasApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
			{
				return false;
			}

			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		public virtual Task LoadAsync()
		{
			return Task.FromResult(0);
		}
	}
}
