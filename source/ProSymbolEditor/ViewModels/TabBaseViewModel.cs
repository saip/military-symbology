using ArcGIS.Desktop.Framework.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSymbolEditor.ViewModels
{
    class TabBaseViewModel : PropertyChangedBase
    {


        public bool IsCoordinateTabEnabled
        {
            get
            {
                return _isCoordinateTabEnabled;
            }
            set
            {
                _isCoordinateTabEnabled = value;

                NotifyPropertyChanged(() => IsCoordinateTabEnabled);
            }
        }
        protected bool _isCoordinateTabEnabled = false;

        public ArcGIS.Core.Geometry.Geometry MapGeometry
        {
            get
            {
                return _mapCoordinates;
            }
            set
            {
                _mapCoordinates = value;
                NotifyPropertyChanged(() => MapGeometry);
            }
        }
        private ArcGIS.Core.Geometry.Geometry _mapCoordinates;

        public bool IsEditing
        {
            get
            {
                return _isEditing;
            }
            set
            {
                _isEditing = value;

                if (_isEditing == false)
                {
                    IsAddingNew = true;
                }
                else
                {
                    IsAddingNew = false;
                }

                NotifyPropertyChanged(() => IsEditing);
            }
        }
        protected bool _isAddingNew = false;

        public bool IsAddingNew
        {
            get
            {
                return _isAddingNew;
            }
            set
            {
                _isAddingNew = value;
                NotifyPropertyChanged(() => IsAddingNew);
            }
        }
        protected bool _isEditing = false;


    }
}
