
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Framework.Threading.Tasks;

using CoordinateConversionLibrary.Models;


namespace ProSymbolEditor.ViewModels
{
    class CoordinateTabViewModel : TabBaseViewModel
    {

        public bool PointCoordinateValid
        {
            get
            {
                return _coordinateValid;
            }
            set
            {
                _coordinateValid = value;
                NotifyPropertyChanged(() => PointCoordinateValid);
            }
        }
        private bool _coordinateValid = false;

        public Visibility PointCoordinateVisibility
        {
            get
            {
                return _pointCoordinateVisibility;
            }
            set
            {
                _pointCoordinateVisibility = value;
                NotifyPropertyChanged(() => PointCoordinateVisibility);
            }
        }
        private Visibility _pointCoordinateVisibility;

        public string MapPointCoordinatesString
        {
            get
            {
                return _mapCoordinatesString;
            }
            set
            {
                _mapCoordinatesString = value;

                MapPoint point;
                var coordType = ProSymbolUtilities.GetCoordinateType(_mapCoordinatesString, out point);

                if (coordType == CoordinateType.Unknown)
                {
                    //Error
                    MapGeometry = null;
                    PointCoordinateValid = false;
                }
                else
                {
                    MapGeometry = point;
                    PointCoordinateValid = true;
                }

                NotifyPropertyChanged(() => MapPointCoordinatesString);
            }
        }
        private string _mapCoordinatesString = "";

        public ObservableCollection<CoordinateObject> PolyCoordinates { get; set; }

        public Visibility PolyCoordinateVisibility
        {
            get
            {
                return _polyCoordinateVisibility;
            }
            set
            {
                _polyCoordinateVisibility = value;
                NotifyPropertyChanged(() => PolyCoordinateVisibility);
            }
        }
        private Visibility _polyCoordinateVisibility;

        public ICommand AddCoordinateToMapCommand { get; set; }

        public ICommand MarkCoordinateOnMapCommand { get; set; }

        private System.IDisposable _overlayObject = null;

        private void RemoveCoordinateMarker()
        {
            if (_overlayObject == null)
                return;

            _overlayObject.Dispose();
            _overlayObject = null;
        }

        private async void MarkCoordinateOnMap(object parameter)
        {
            if (MapView.Active == null) // should not happen
                return;

            MapPoint markerPoint = null;

            if (MapGeometry is MapPoint)
            {
                markerPoint = MapGeometry as MapPoint;
            }
            else if ((PolyCoordinates != null) && (PolyCoordinates.Count > 1))
            {
                // Use the last point in the collection to mark/zoom to
                CoordinateObject coordObject = PolyCoordinates.Last();

                markerPoint = coordObject.MapPoint;
            }

            if (markerPoint == null)  // should not happen, but last check 
                return;

            await QueuedTask.Run(() =>
            {
                RemoveCoordinateMarker();

                var coordinateMarker = ArcGIS.Desktop.Mapping.SymbolFactory.Instance.ConstructMarker(ArcGIS.Desktop.Mapping.ColorFactory.Instance.RedRGB, 12,
                    ArcGIS.Desktop.Mapping.SimpleMarkerStyle.Circle);

                ArcGIS.Core.CIM.CIMPointSymbol _pointCoordSymbol =
                    ArcGIS.Desktop.Mapping.SymbolFactory.Instance.ConstructPointSymbol(coordinateMarker);

                _overlayObject = MapView.Active.AddOverlay(markerPoint, _pointCoordSymbol.MakeSymbolReference());

                MapView.Active.ZoomTo(markerPoint);
            });
        }

        // IsCoordinateTabEnabled

        // PointCoordinateValid

        // MapPointCoordinatesString
        // PointCoordinateVisibility
        // 
        // PolyCoordinates
        // PolyCoordinateVisibility

        // IsAddingNew
        // 

        // AddCoordinateToMapCommand
        // MarkCoordinateOnMapCommand


    }

}
