/*******************************************************************************
 * Copyright 2018 Esri
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 *  
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework.Contracts;

namespace ProSymbolEditor.ViewModels
{
    class DockpaneViewModel : DockPane, IDataErrorInfo
    {

        public ProSymbolEditor.Views.SearchView SearchTabView { get; set; }

        public Views.ModifyView ModifyTabView { get; set; }

        public Views.FavoritesView FavoritesTabView { get; set; }

        public Views.SymbolView SymbolTabView { get; set; }

        public Views.LabelView LabelTabView { get; set; }

        public Views.CoordinateView CoordinateTabView { get; set; }
        public CoordinateTabViewModel CoordinateViewModel { get; set; }

        //Member Variables
        private const string _dockPaneID = "ProSymbolEditor_MilitarySymbolDockpane";
        private const string _menuID = "ProSymbolEditor_MilitarySymbolDockpane_Menu";

        public DockpaneViewModel()
        {
            //SearchTabView = new Views.SearchView();
            //SearchTabView.DataContext = this;

            //ModifyTabView = new Views.ModifyView();
            //ModifyTabView.DataContext = this;

            //FavoritesTabView = new Views.FavoritesView();
            //FavoritesTabView.DataContext = this;

            //SymbolTabView = new Views.SymbolView();
            //SymbolTabView.DataContext = this;

            //LabelTabView = new Views.LabelView();
            //LabelTabView.DataContext = this;

            CoordinateTabView = new Views.CoordinateView();
            CoordinateViewModel = new CoordinateTabViewModel();
            CoordinateTabView.DataContext = CoordinateViewModel;
        }

        #region IDataErrorInfo Interface
        public string Error { get; set; }

        public string this[string columnName]
        {
            get
            {
                Error = null;

                switch (columnName)
                {
                    case "MapPointCoordinatesString":
                        if (!CoordinateViewModel.PointCoordinateValid)
                        {
                            Error = "The coordinates are invalid";
                        }
                        break;
                }

                return Error;
            }
        }
        #endregion


    }

}
