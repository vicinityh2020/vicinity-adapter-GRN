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
    public class ReadWriteLink
    {
        #region Constructor
        public ReadWriteLink(string href, InOutput output, InOutput input = null)
        {
            Href = href;
            Output = output;
            Input = input;
        }
        #endregion

        #region Properties

        #region Public

        #region Href
        [JsonProperty(PropertyName = "href")]
        public string Href { set; get; }
        #endregion

        #region StaticValue
        [JsonProperty(PropertyName = "static-value")]
        public StaticValue StaticValue { get; set; }
        #endregion

        #region Input
        [JsonProperty(PropertyName = "input")]
        public InOutput Input { get; set; }
        #endregion

        #region Output
        [JsonProperty(PropertyName = "output")]
        public InOutput Output { get; set; }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ShouldSerializeInput
        public bool ShouldSerializeInput()
        {
            return Input != null && Input.Fields != null && Input.Fields.Count > 0;
        }
        #endregion

        #region ShouldSerializeStaticValue
        public bool ShouldSerializeStaticValue()
        {
            return StaticValue != null && !string.IsNullOrEmpty(StaticValue.Property) && StaticValue.Value != null;
        }
        #endregion

        #endregion

        #endregion
    }
}
