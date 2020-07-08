﻿using AnimalShelterManagementSystem.WinForm.AdminForms;
using AnimalShelterManagementSystem.WinForm.Forms;
using AnimalShelterManagementSystem.WinForm.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalShelterManagementSystem.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //안녕
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomelessAnimalListForm());
        }
    }
}
