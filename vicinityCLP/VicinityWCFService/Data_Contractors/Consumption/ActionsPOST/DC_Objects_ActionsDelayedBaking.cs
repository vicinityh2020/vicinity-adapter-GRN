/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{

    #region POST method
    

    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_ActionsDelayedBaking
    {
        [DataMember(Name = "duration", IsRequired = true)]
        public string Duration { get; set; }
        [DataMember(Name = "delay", IsRequired = true)]
        public string Delay { get; set; }
        [DataMember(Name = "temperature", IsRequired = true)]
        public string Temperature { get; set; }
        [DataMember(Name = "heater_system", IsRequired = true)]
        public string HeaterSystem { get; set; }
    }

    #endregion

}
