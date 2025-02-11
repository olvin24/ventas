﻿using BL.Citas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.CitasMedicas
{
    public partial class FormReporteFacturas : Form
    {
        public FormReporteFacturas()
        {
            InitializeComponent();
            // para enlazar nuestro reporte Facturas 
            var _facturasBL = new FacturaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturasBL.ObtenerFacturas();
           
           
            var reporte = new ReporteFacturas();
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
