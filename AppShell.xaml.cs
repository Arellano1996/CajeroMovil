﻿using CajeroMovil.MVVM.Views;
namespace CajeroMovil;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(QRScan), typeof(QRScan));
        Routing.RegisterRoute(nameof(Pagar), typeof(Pagar));
    }
}

