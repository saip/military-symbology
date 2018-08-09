/*******************************************************************************
 * Copyright 2016 Esri
 * 
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 *  
 *   Unless required by applicable law or agreed to in writing, software
 *   distributed under the License is distributed on an "AS IS" BASIS,
 *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *   See the License for the specific language governing permissions and
 *   limitations under the License.
 ******************************************************************************/
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProSymbolEditor
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : ArcGIS.Desktop.Framework.Controls.ProWindow
    {

        // Radio Button binding special case:
        // WPF does not enforce only-one-item-checked behavior, so need to do in code behind
        public bool Checked2525D
        {
            get { return _checked2525D; }
            set
            {
                _checked2525D = value;
                if (_checked2525D)
                {
                    _checked2525C_B2 = false;
                    _checkedAPP6D = false;
                }
            }
        }
        bool _checked2525D;

        public bool Checked2525C_B2
        {
            get { return _checked2525C_B2; }
            set
            {
                _checked2525C_B2 = value;
                if (_checked2525C_B2)
                {
                    _checked2525D = false;
                    _checkedAPP6D = false;
                }
            }
        }
        bool _checked2525C_B2;

        public bool CheckedAPP6D
        {
            get { return _checkedAPP6D; }
            set
            {
                _checkedAPP6D = value;
                if (_checkedAPP6D)
                {
                    _checked2525D = false;
                    _checked2525C_B2 = false;
                }
            }
        }
        bool _checkedAPP6D;

        public SettingsWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public void ShowDialog(Window owner)
        {
            this.Owner = owner;
            this.ShowDialog();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
