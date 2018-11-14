# 1. Infrastructure overview
VICINITY Adapter for Gorenje appliances

# 2. Configuration and deployment


# 3. Functionality and API

## Endpoints

## Functions

### Oven 

#### Oven properties

#### Device status

PID: device_status  
Device status property has only GET method that returns device status.

**GET method**  
After executing GET method we receive following response:  
{  
    " device_status ": "IDLE"  
}

#### Light 

PID: light  
Light property has GET method that returns light status and PUT method that change light status.

**GET method**  
After executing GET method we receive following response:  
{  
    "light": "ON"  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "light": "OFF"  
}

**Parameters**
* light: (string), possible values: ON and OFF. 

**Returns**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Child lock

PID: child_lock  
Child lock property has GET method that returns child lock status and PUT method that change child lock status.

**GET method**  
After executing GET method we receive following response:  
{  
    "child_lock": "OFF"  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "child_lock": "ON"  
}

**Parameters**
* child_lock: (string), possible values: ON and OFF.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Door

PID: door  
Door property has only GET method that returns door status.

**GET method**  
After executing GET method we receive following response:  
{  
    "door": "CLOSED"  
}

#### Current temperature

PID: current_temperature  
Current temperature property has only GET method that returns appliance current temperature in Celsius.

**GET method**  
After executing GET method we receive following response:  
{  
    "current_temperature": 120  
}

#### Current meat probe temperature

PID: current_meat_probe_temperature  
Current meat probe temperature property has only GET method that returns current meat probe temperature in Celsius. If there is no meat the result will be 0 Celsius otherwise it will be 30 Celsius or more.

**GET method**  
After executing GET method we receive following response:  
{  
    "current_meat_probe_temperature":  0  
}

#### Heater system

PID: heater_system  
Heater system property has GET method that returns selected heater system and PUT method that change heater system.

**GET method**  
After executing GET method we receive following response:  
{  
    "heater_system": "ECOHOTAIR"  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "heater_system": "proroasting"  
} 

**Parameters**	
* heater_system: (string), possible values: hotair, ecohotair, topbottom, hotairbottom, bottomfan, bottom, top, smallgrill, largegrill, largegrillfan and proroasting.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}
#### Selected heater min temperature

PID: selected_heater_min_temperature  
Selected heater min temperature property has only GET method that returns minimum temperature in Celsius for selected heater.

**GET method**  
After executing GET method we receive following response:  
{  
    "selected_heater_min_temperature": 30  
}

#### Selected heater max temperature

PID: selected_heater_max_temperature  
Selected heater max temperature property has only GET method that returns maximum temperature in Celsius for selected heater.

**GET method**  
After executing GET method we receive following response:  
{  
    "selected_heater_max_temperature": 270  
}

#### Selected heater default temperature

PID: selected_heater_default_temperature  
Selected heater default temperature property has only GET method that returns default temperature in Celsius for selected heater.

**GET method**  
After executing GET method we receive following response:  
{  
    "selected_heater_default_temperature": 180  
}

#### Selected heater meat probe allowed

PID: selected_heater_meat_probe_allowed  
Selected heater meat probe allowed property has only GET method that returns true if meat probe is allowed for selected heater or false if it isn’t.

**GET method**  
After executing GET method we receive following response:  
{  
    "selected_heater_meat_probe_allowed": "true"  
}

#### Selected heater preheat allowed

PID: selected_heater_preheat_allowed  
Selected heater preheat allowed property has only GET method that returns true if preheat is allowed for selected heater or false if it isn’t.

**GET method**  
After executing GET method we receive following response:  
{  
    "selected_heater_preheat_allowed": "true"  
}

#### Set meat probe temperature

PID: set_meat_probe_temperature  
Set meat probe temperature property has GET method that returns current meat probe temperature in Celsius (if there is no meat the result will be 0 Celsius otherwise it will be 30 Celsius or more) and PUT method that set meat probe temperature.

**GET method**  
After executing GET method we receive following response:  
{  
    "set_meat_probe_temperature": 0  
} 

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "set_meat_probe_temperature": 50  
} 

**Parameters**
* set_meat_probe_temperature: (integer), possible values: in the range from 30 to 75 Celsius.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Set baking temperature

PID: set_baking_temperature  
Set baking temperature property has GET method that returns baking temperature in Celsius and PUT method that set baking temperature.

**GET method**  
After executing GET method we receive following response:  
{  
    "set_baking_temperature": 200  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "set_baking_temperature": 120  
}

**Parameters**
* set_baking_temperature: (integer), possible values: in the range from 30 to 270 Celsius.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Set baking time

PID: set_baking_time  
Set baking time property has GET method that returns baking time in minutes and PUT method that set baking time.

**GET method**  
After executing GET method we receive following response:  
{  
    "set_baking_time": 15  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "set_baking_time": 35  
}

**Parameters**
set_baking_time: (integer), possible values: in the range from 1 to 599 minutes.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Alarm time

PID: alarm_time  
Alarm time property has GET method that returns alarm time in minutes and PUT method that set alarm time.

**GET method**  
After executing GET method we receive following response:  
{  
    "alarm_time": 0  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "alarm_time": 10  
}

**Parameters**
* alarm_time: (integer), possible values: in the range from 0 to 599 minutes.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Bake elapsed time

PID: bake_elapsed_time  
Bake elapsed time property has only GET method that returns elapsed time in minutes.

**GET method**  
After executing GET method we receive following response:  
{  
    "bake_elapsed_time": 4  
}


#### Bake remaining time

PID: bake_remaining_time  
Bake remaining time property has only GET method that returns remaining time in minutes.

**GET method**  
After executing GET method we receive following response:  
{  
    "bake_remaining_time": 0  
}

####	Baking start time hour

PID: baking_start_time_hour  
Baking start time hour property has GET method that returns baking start time in hours and PUT method that set baking start time.

**GET method**  
After executing GET method we receive following response:  
{  
    "baking_start_time_hour": 0  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "baking_start_time_hour": 9  
}

**Parameters**
* baking_start_time_hour: (integer), possible values: in the range from 0 to 23 hours.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Baking start time minute 

PID: baking_start_time_minute  
Baking start time minute property has GET method that returns baking start time in minutes and PUT method that set baking start time.

**GET method**  
After executing GET method we receive following response:  
{  
    "baking_start_time_minute": 0  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "baking_start_time_minute": 10  
}

**Parameters**
* baking_start_time_minute: (integer), possible values: in the range from 0 to 59 minutes.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Oven actions

#### Delayed baking

AID: delayed_baking  
Delayed baking action has GET method that returns information’s about delayed baking (if delay baking status is IDLE or RUNNING it will return default values for other parameters otherwise it will return set values) and POST method that set delayed baking.

**GET method**  
After executing GET method we receive following response:  
{  
    "delayed_baking": "IDLE",  
    "start_baking_at": "0:00",  
    "duration": 0,  
    "delay": 0,  
    "temperature": 30,  
    "heater_system": "hotair"  
}

**POST method**  
For POST method request we need to add following JSON:  
{  
    "duration": 15,  
    "delay": 1,  
    "temperature": 200,  
    "heater_system": "ecohotair"  
}

**Parameters**
* duration: (integer), possible values: in the range from 0 to 599 minutes.
* delay: (integer), possible values: in the range from 0 to 599 minutes.
* temperature: (integer), possible values: in the range from 30 to 270 Celsius.
* heater_system: (string), possible values: hotair, ecohotair, topbottom, hotairbottom, bottomfan, bottom, top, smallgrill, largegrill, largegrillfan and proroasting.

**Return**  
After executing POST method we receive following response:  
{  
    "result": "true"  
}

#### Baking

AID: baking  
Baking action has GET method that returns information’s about baking (duration in minutes, temperature in Celsius and selected heater system) and POST method that set baking.

**GET method**  
After executing GET method we receive following response:  
{  
    "duration": 15,  
    "temperature": 200,  
    "heater_system": "ECOHOTAIR"  
}

**POST method**  
For POST method request we need to add following JSON:  
{  
    "duration": 30,  
    "temperature": 180,  
    "heater_system": "hotair"  
}

**Parameters**
* duration: (integer), possible values: in the range from 0 to 599.
* temperature: (integer), possible values: in the range from 30 to 270.
* heater_system: (string), possible values: hotair, ecohotair, topbottom, hotairbottom, bottomfan, bottom, top, smallgrill, largegrill, largegrillfan and proroasting.

**Return**  
After executing POST method we receive following response:  
{  
    "result": "true"  
}

#### Start

AID: start  
Start action has only POST method that starts baking.

**POST method**  
For POST method request we need to add following JSON:  
{  
    "id": 1  
}

**Parameters**
* id: (integer), possible values: any integer number

**Return**  
After executing POST method we receive following response:  
{  
    "result": "true"  
}

#### Stop

AID: stop  
Stop action has only POST method that stops baking.

**POST method**  
For POST method request we need to add following JSON:  
{  
    "id": 1  
}

**Parameters**
* id: (integer), possible values: any integer number

**Return**  
After executing POST method we receive following response:  
{  
    "result": "true"  
}

#### Oven events

#### Device status
You can subscribe to oven device status event to receive notification when device status change. Event ID for oven device status is: device_status. For example subscriber receive following JSON:  
{  
	"Name": "Smart oven 3",  
	"AUID": "0000000000001321320001201800000000011",  
    "device_status": "RUNNING",  
    "Timestamp": "26. 10. 2018 10:13:14"  
}  
  
Properties explanation:  
Name: Unique name in NM  
AUID: Unique appliance identifier number (37 digits)  
device_status: possible values: "IDLE", "RUNNING"(baking in progress), "PAUSE"(baking is paused), "AFTER_BAKE"(baking has ended), "DELAY_TIME_WAITING"(delayed baking mode)  
Timestamp: UTC value when event happened 

#### Door
You can subscribe to oven door event to receive notification when door status change. Event ID for oven door is: door. For example subscriber receive following JSON:  
{  
	"Name": "Smart oven 1",  
	"AUID": "0000000000001321320001201800000000012",  
    "door": "OPENED",  
    "Timestamp": "26. 10. 2018 10:13:14"  
}  
  
Properties explanation:  
Name: Unique name in NM  
AUID: Unique appliance identifier number (37 digits)  
door: door status, possible values: "OPENED" or "CLOSED"  
Timestamp: UTC value when event happened  



### Refrigerator

#### Refrigerator properties

#### Device status

PID: device_status  
Device status property has only GET method that returns device status.

**GET method**  
After executing GET method we receive following response:  
{  
    "device_status": "NORMAL_MODE"  
}

#### Refrigerator light

PID: refrigerator_light  
Refrigerator light property has only GET method that returns refrigerator light status.

**GET method**  
After executing GET method we receive following response:  
{  
    "refrigerator_light": "OFF"  
}

#### Freezer light

PID: freezer_light  
Freezer light property has only GET method that returns freezer light status.

**GET method**  
After executing GET method we receive following response:  
{  
    "freezer_light": "OFF"  
}

#### Refrigerator door

PID: refrigerator_door  
Refrigerator door property has only GET method that returns refrigerator door status.

**GET method**  
After executing GET method we receive following response:  
{  
    "refrigerator_door": "CLOSED"  
} 
#### Freezer door

PID: freezer_door  
Freezer door property has only GET method that return freezer door status.

**GET method**  
After executing GET method we receive following response:  
{  
    "freezer_door": "CLOSED"  
}

#### Refrigerator temperature

PID: refrigerator_temperature  
Refrigerator temperature property has GET method that returns refrigerator temperature in Celsius and PUT method that change refrigerator temperature.

**GET method**  
After executing GET method we receive following response:  
{  
    "refrigerator_temperature": 5  
} 

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "refrigerator_temperature": 4  
} 

**Parameters**
* refrigerator_temperature: (integer), possible values: in the range from 3 to 8 Celsius.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Freezer temperature

PID: freezer_temperature  
Freezer temperature property has GET method that returns freezer temperature in Celsius and PUT method that change freezer temperature.

**GET method**  
After executing GET method we receive following response:  
{  
    "freezer_temperature": -22  
} 

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "freezer_temperature": -18  
} 

**Parameters**
* freezer_temperature: (integer), possible values: in the range from -24 to -16 Celsius.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Fastfreeze

PID: fastfreeze  
Fastfreeze property has GET method that returns fastfreeze status and PUT method that turns on or off fastfreeze.

**GET method**  
After executing GET method we receive following response:  
{  
    "fastfreeze": "OFF"  
} 

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "fastfreeze": "ON"  
} 

**Parameters**
* fastfreeze: (string), possible values: ON and OFF.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Supercool

PID: supercool  
Supercool property has GET that returns supercool status and PUT method that turns on or off supercool.

**GET method**  
After executing GET method we receive following response:  
{  
    "supercool": "OFF"  
} 

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "supercool": "ON"  
} 

**Parameters**
* supercool: (string), possible values: ON and OFF.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Childlock

PID: child_lock  
Childlock property has GET method that returns child lock status and PUT method that change child lock status.

**GET method**  
After executing GET method we receive following response:  
{  
    "child_lock": "ON"  
}

**PUT method**  
For PUT method request we need to add following JSON:  
{  
    "child_lock": "OFF"  
}

**Parameters**
* child_lock: (string), possible values: ON and OFF.

**Return**  
After executing PUT method we receive following response:  
{  
    "result": "true"  
}

#### Refrigerator events

#### Refrigerator door
You can subscribe to refrigerator door event to receive notification when door status change. Event ID for refrigerator door is: refrigerator_door. For example subscriber receive following JSON:  
{  
	"Name": "Smart refrigerator 1",  
	"AUID": "0000000000001321320001201800000000013",  
    "refrigerator_door": "OPENED",  
    "Timestamp": "26. 10. 2018 10:13:14"  
}  
  
Properties explanation:  
Name: Unique name in NM  
AUID: Unique appliance identifier number (37 digits)  
refrigerator_door: refrigerator door status, possible values: "OPENED" or "CLOSED"  
Timestamp: UTC value when event happened  


#### Freezer door
You can subscribe to freezer door event to receive notification when door status change. Event ID for freezer door is: freezer_door. For example subscriber receive following JSON:  
{  
	"Name": "Smart refrigerator 2",  
	"AUID": "0000000000001321320001201800000000014",  
    "freezer_door": "CLOSED",  
    "Timestamp": "26. 10. 2018 10:09:11"  
}  
  
Properties explanation:  
Name: Unique name in NM  
AUID: Unique appliance identifier number (37 digits)  
freezer_door: freezer door status, possible values: "OPENED" or "CLOSED"  
Timestamp: UTC value when event happened  