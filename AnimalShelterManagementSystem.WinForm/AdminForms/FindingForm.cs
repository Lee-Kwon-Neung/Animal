﻿       using AnimalShelterManagementSystem.Data;
using AnimalShelterManagementSystem.Models;
using AnimalShelterManagementSystem.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalShelterManagementSystem.WinForm.AdminForms
{
    public partial class FindingForm : DevExpress.XtraEditors.XtraForm
    {
        private FindingReport findingReport;
        private bool WasInShelter;
        public FindingForm()
        {
            InitializeComponent();
            findingReport = new FindingReport();

        }
        public FindingForm(FindingReport findingReport)
        {
            InitializeComponent();
            this.findingReport = findingReport;
            cbxSpecies.SelectedItem = findingReport.Species;
            dteDate.DateTime = findingReport.Date;
            txbPlace.Text = findingReport.Place;
            rdgIsInShelter.EditValue = findingReport.IsInShelter? 1 : 0;
            WasInShelter = findingReport.IsInShelter;
        }

        private void InShelter()
        {
            HomelessAnimal homelessAnimal = new HomelessAnimal();
            homelessAnimal.Species = findingReport.Species;
            homelessAnimal.HomelessAnimalId = DataRepository.HomelessAnimal.GetMaxId() + 1;
            HomelessAnimalForm homelessAnimalForm = new HomelessAnimalForm(homelessAnimal);
            homelessAnimalForm.ShowDialog();

            FindingReportRecord findingReportRecord = new FindingReportRecord(); 
        }

        private void Add()
        {
            WasInShelter = true;
            findingReport.FindingReportId = DataRepository.FindingReport.GetMaxId() + 1;
            findingReport.Species = (int)((SpeciesType)Enum.Parse(typeof(SpeciesType), cbxSpecies.Text));
            findingReport.Date = dteDate.DateTime;
            findingReport.Place = txbPlace.Text;
            findingReport.IsInShelter = Convert.ToBoolean(rdgIsInShelter.EditValue);
            if (findingReport.IsInShelter == true)
            {
                //InShelter();
            
            }
            DataRepository.FindingReport.Insert(findingReport);
            LoadHomelessAnimal();
            Close();
            return;


        }

        private void Edit()
        {
            findingReport.Species = (int)((SpeciesType)Enum.Parse(typeof(SpeciesType), cbxSpecies.Text));
            findingReport.Date = dteDate.DateTime;
            findingReport.Place = txbPlace.Text;
            findingReport.IsInShelter = Convert.ToBoolean(rdgIsInShelter.EditValue);
            DataRepository.FindingReport.Update(findingReport);
            LoadHomelessAnimal();
            Close();
            return;

        }

        private void FindingForm_Load(object sender, EventArgs e)
        {
            cbxSpecies.DataSource = Enum.GetValues(typeof(SpeciesType));
        }

        private void LoadHomelessAnimal()
        {
            if (findingReport.IsInShelter == true && WasInShelter == false)
            {
                HomelessAnimalForm homelessAnimalForm = new HomelessAnimalForm(findingReport);
                homelessAnimalForm.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (findingReport.FindingReportId == DataRepository.FindingReport.GetMaxId() + 1)
            {
                Add();
            }
            else
            {
                Edit();
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
