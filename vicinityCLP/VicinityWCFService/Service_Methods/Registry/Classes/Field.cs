/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using Newtonsoft.Json;

namespace VicinityWCF
{
    public class Field
    {
        #region Constructor
        public Field(string name, string description, Schema schema, string predicate = null)
        {
            Name = name;
            Description = description;
            Schema = schema;
            Predicate = predicate;
        }
        #endregion

        #region Properties

        #region Public

        #region Name
        [JsonProperty(PropertyName = "name")]
        public string Name { set; get; }
        #endregion

        #region Predicate
        [JsonProperty(PropertyName = "predicate")]
        public string Predicate { set; get; }
        #endregion

        #region Description
        [JsonProperty(PropertyName = "description")]
        public string Description { set; get; }
        #endregion

        #region Schema
        [JsonProperty(PropertyName = "schema")]
        public Schema Schema { set; get; }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ShouldSerializePredicate
        public bool ShouldSerializePredicate()
        {
            return !string.IsNullOrEmpty(Predicate);
        }
        #endregion

        #endregion

        #endregion
    }
}
