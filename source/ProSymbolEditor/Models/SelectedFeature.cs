﻿/*******************************************************************************
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

using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSymbolEditor
{
    public class SelectedFeature : PropertyChangedBase
    {
        public BasicFeatureLayer FeatureLayer { get; set; }
        public string FeatureLayerName { get; set; }
        public long ObjectId { get; set; }
        public string SymbolSetName { get; set; }
        public string EntityName { get; set; }

        public SelectedFeature() { }

        public SelectedFeature(BasicFeatureLayer featureLayer, long objectId)
        {
            FeatureLayer = featureLayer;

            if (featureLayer != null)
                FeatureLayerName = featureLayer.Name;

            ObjectId = objectId;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FeatureLayerName);
            sb.Append(ProSymbolUtilities.NameSeparator);
            sb.Append(SymbolSetName);
            if (!string.IsNullOrEmpty(EntityName))
            {
                sb.Append(ProSymbolUtilities.NameSeparator);
                sb.Append(EntityName);
            }

            return sb.ToString();
        }
    }
}
