/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System;
using System.Collections.Generic;

namespace VicinityWCF
{
    public enum RequestActionType
    {
        OVEN_DELAYED_BAKING,
        OVEN_BAKING,
        OVEN_LIGHT,
        OVEN_CHILD_LOCK,
        OVEN_HEATER_SYSTEM,
        OVEN_SET_MEAT_PROBE_TEMPERATURE,
        OVEN_SET_BAKING_TEMPERATURE,
        OVEN_SET_BAKING_TIME,
        OVEN_ALARM_TIME,
        OVEN_BAKING_START_TIME_HOUR,
        OVEN_BAKING_START_TIME_MINUTE,
        OVEN_BAKING_START,
        OVEN_BAKING_STOP,
        REFRIGERATOR_TEMPERATURE,
        REFRIGERATOR_FREEZER_TEMPERATURE,
        REFRIGERATOR_FASTFREEZE,
        REFRIGERATOR_SUPERCOOL,
        REFRIGERATOR_CHILD_LOCK,
        none
    }

    public class HTTPRequestEventArgs : EventArgs
    {
        public bool clp_params_request;

        public Dictionary<string, string> clp_params;

        public RequestActionType action_type;
        public bool action_executed;

        public string AUID;

        public HTTPRequestEventArgs(string AUID)
        {
            clp_params_request = false;
            clp_params = null;

            action_type = RequestActionType.none;
            action_executed = false;

            this.AUID = AUID;
        }
    }
}
