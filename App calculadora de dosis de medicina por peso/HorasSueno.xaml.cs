﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App9
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HorasSueno : ContentPage
	{
		public HorasSueno ()
		{
			InitializeComponent ();
            btnGuardar.Clicked += BtnGuardar_Clicked;
            btnRecuperar.Clicked += BtnRecuperar_Clicked;

            var navigationPage = new NavigationPage(this);
            navigationPage.BarBackgroundColor = Color.FromHex("#F5F5F5");
            Application.Current.MainPage = navigationPage;
        }
        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            string nombreArchivo = "horasueno.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (!File.Exists(rutaCompleta))
            {
                using (var escritor = File.CreateText(rutaCompleta))
                {
                    escritor.Write(txtGuardar.Text);
                    DisplayAlert("Guardar datos", "Las horas de sueño han sido guardadas.", "Aceptar");

                }
            }
            else
            {
                using (var escritor = File.AppendText(rutaCompleta))
                {
                    escritor.Write(txtGuardar.Text);
                    DisplayAlert("Guardar datos", "Las horas de sueño han sido guardadas.", "Aceptar");

                }
            }

            txtGuardar.Text = "";
        }

        private void BtnRecuperar_Clicked(object sender, EventArgs e)
        {
            string nombreArchivo = "horasueno.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                using (var lector = new StreamReader(rutaCompleta, true))
                {
                    string textoLeido;
                    while ((textoLeido = lector.ReadLine()) != null)
                    {
                        txtRecuperar.Text = textoLeido;
                    }
                }
            }
        }

        private void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            string nombreArchivo = "horasueno.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
                txtRecuperar.Text = "";
                DisplayAlert("Borrar datos", "Las horas de sueño han sido borrados.", "Aceptar");
            }
            else
            {
                DisplayAlert("Borrar datos", "No hay horas de sueño para borrar.", "Aceptar");
            }
        }
    }
}