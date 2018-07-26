# 1. Infrastructure overview
VICINITY Adapter for Gorenje appliances

# 2. Configuration and deployment


# 3. Functionality and API

## Endpoints

## Functions

### Oven 

#### Oven properties

#### Device status

Device status property has only GET method that returns device status. 

**GET method**  
After executing GET method we receive following response:
{  
    " device-status ": "IDLE"  
}

#### Light 

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
Child lock property has GET method that returns child lock status and PUT method that change child lock status.

**GET method**
After executing GET method we receive following response:
{
    "child-lock": "OFF"
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "child-lock": "ON"
}

**Parameters**
* child-lock: (string), possible values: ON and OFF.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Door
Door property has only GET method that returns door status.

**GET method**
After executing GET method we receive following response:
{
    "door-sensor": "CLOSED"
}

#### Current temperature
Current temperature property has only GET method that returns appliance current temperature in Celsius.

**GET method**
After executing GET method we receive following response:
{
    "current-temperature": 120
}

#### Current meat probe temperature
Current meat probe temperature property has only GET method that returns current meat probe temperature in Celsius. If there is no meat the result will be 0 Celsius otherwise it will be 30 Celsius or more.

**GET method**
After executing GET method we receive following response:
{
    "current-meat-probe-temperature":  0
}

#### Heater system
Heater system property has GET method that returns selected heater system and PUT method that change heater system.

**GET method**
After executing GET method we receive following response:
{
    "heater-system": "ECOHOTAIR"
}

**PUT method** 
For PUT method request we need to add following JSON:
{
    "heater-system": "proroasting"
} 

**Parameters**	
* heater-system: (string), possible values: hotair, ecohotair, topbottom, hotairbottom, bottomfan, bottom, top, smallgrill, largegrill, largegrillfan and proroasting.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}
#### Selected heater min temperature
Selected heater min temperature property has only GET method that returns minimum temperature in Celsius for selected heater.

**GET method**
After executing GET method we receive following response:
{
    "selected-heater-min-temperature": 30
}

#### Selected heater max temperature
Selected heater max temperature property has only GET method that returns maximum temperature in Celsius for selected heater.

**GET method**
After executing GET method we receive following response:
{
    "selected-heater-max-temperature": 270
}

#### Selected heater default temperature
Selected heater default temperature property has only GET method that returns default temperature in Celsius for selected heater.

**GET method**
After executing GET method we receive following response:
{
    "selected-heater-default-temperature": 180
}

#### Selected heater meat probe allowed
Selected heater meat probe allowed property has only GET method that returns true if meat probe is allowed for selected heater or false if it isn’t.

**GET method**
After executing GET method we receive following response:
{
    "selected-heater-meat-probe-allowed": "true"
}

#### Selected heater preheat allowed
Selected heater preheat allowed property has only GET method that returns true if preheat is allowed for selected heater or false if it isn’t.

**GET method**
After executing GET method we receive following response:
{
    "selected-heater-preheat-allowed": "true"
}

#### Set meat probe temperature
Set meat probe temperature property has GET method that returns current meat probe temperature in Celsius (if there is no meat the result will be 0 Celsius otherwise it will be 30 Celsius or more) and PUT method that set meat probe temperature.

**GET method**
After executing GET method we receive following response:
{
    "set-meat-probe-temperature": 0
} 

**PUT method**
For PUT method request we need to add following JSON:
{
    "set-meat-probe-temperature": 50
} 

**Parameters**
* set-meat-probe-temperature: (integer), possible values: in the range from 30 to 75 Celsius.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Set baking temperature
Set baking temperature property has GET method that returns baking temperature in Celsius and PUT method that set baking temperature.

**GET method**
After executing GET method we receive following response:
{
    "set-baking-temperature": 200
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "set-baking-temperature": 120
}

**Parameters**
* set-baking-temperature: (integer), possible values: in the range from 30 to 270 Celsius.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Set baking time
Set baking time property has GET method that returns baking time in minutes and PUT method that set baking time.

**GET method**
After executing GET method we receive following response:
{
    "set-baking-time": 15
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "set-baking-time": 35
}

**Parameters**
set-baking-time: (integer), possible values: in the range from 1 to 599 minutes.
Return
After executing PUT method we receive following response:
{
    "result": "true"
}
#### Alarm time
Alarm time property has GET method that returns alarm time in minutes and PUT method that set alarm time.

**GET method**
After executing GET method we receive following response:
{
    "alarm-time": 0
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "alarm-time": 10
}

**Parameters**
* alarm-time: (integer), possible values: in the range from 0 to 599 minutes.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Bake elapsed time
Bake elapsed time property has only GET method that returns elapsed time in minutes.

**GET method**
After executing GET method we receive following response:
{
    "bake-elapsed-time": 4
}


#### Bake remaining time
Bake remaining time property has only GET method that returns remaining time in minutes.

**GET method**
After executing GET method we receive following response:
{
    "bake-remaining-time": 0
}

####	Baking start time hour
Baking start time hour property has GET method that returns baking start time in hours and PUT method that set baking start time.

**GET method**
After executing GET method we receive following response:
{
    "baking-start-time-hour": 0
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "baking-start-time-hour": 9
}

**Parameters**
* baking-start-time-hour: (integer), possible values: in the range from 0 to 23 hours.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Baking start time minute 
Baking start time minute property has GET method that returns baking start time in minutes and PUT method that set baking start time.

**GET method**
After executing GET method we receive following response:
{
    "baking-start-time-minute": 0
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "baking-start-time-minute": 10
}

**Parameters**
* baking-start-time-minute: (integer), possible values: in the range from 0 to 59 minutes.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Baking end time hour
Baking end time hour has only GET method that returns baking end time in hours.

**GET method**
After executing GET method we receive following response:
{
    "baking-end-time-hour": 0
}

#### Baking end time minute
Baking end time minute property has only GET method that returns baking end time in minutes.

**GET method**
After executing GET method we receive following response:
{
    "baking-end-time-minute": 0
}

#### Oven actions

#### Delayed baking
Delayed baking action has GET method that returns information’s about delayed baking (if delay baking status is IDLE or RUNNING it will return default values for other parameters otherwise it will return set values) and POST method that set delayed baking.

**GET method**
After executing GET method we receive following response:
{
    "delayed-baking-status": "IDLE",
    "start-baking-at": "0:00",
    "duration": 0,
    "delay": 0,
    "temperature": 30,
    "heater-system": "hotair"
}

**POST method**
For POST method request we need to add following JSON:
{
    "duration": 15,
    "delay": 1,
    "temperature": 200,
    "heater-system": "ecohotair"
}

**Parameters**
* duration: (integer), possible values: in the range from 0 to 599 minutes.
* delay: (integer), possible values: in the range from 0 to 599 minutes.
* temperature: (integer), possible values: in the range from 30 to 270 Celsius.
* heater-system: (string), possible values: hotair, ecohotair, topbottom, hotairbottom, bottomfan, bottom, top, smallgrill, largegrill, largegrillfan and proroasting.

**Return**
After executing POST method we receive following response:
{
    "result": "true"
}

#### Baking
Baking action has GET method that returns information’s about baking (duration in minutes, temperature in Celsius and selected heater system) and POST method that set baking.

**GET method**
After executing GET method we receive following response:
{
    "duration": 15,
    "temperature": 200,
    "heater-system": "ECOHOTAIR"
}

**POST method**
For POST method request we need to add following JSON:
{
    "duration": 30,
    "temperature": 180,
    "heater-system": "hotair"
}

**Parameters**
* duration: (integer), possible values: in the range from 0 to 599.
* temperature: (integer), possible values: in the range from 30 to 270.
* heater-system: (string), possible values: hotair, ecohotair, topbottom, hotairbottom, bottomfan, bottom, top, smallgrill, largegrill, largegrillfan and proroasting.

**Return**
After executing POST method we receive following response:
{
    "result": "true"
}

#### Start
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
 
### Refrigerator

#### Refrigerator properties

#### Device status
Device status property has only GET method that returns device status.

**GET method**
After executing GET method we receive following response:
{
    "device-status": "NORMAL_MODE"
}

#### Refrigerator light
Refrigerator light property has only GET method that returns refrigerator light status.

**GET method**
After executing GET method we receive following response:
{
    "refrigerator-light": "OFF"
}

#### Freezer light
Freezer light property has only GET method that returns freezer light status.

**GET method**
After executing GET method we receive following response:
{
    "freezer-light": "OFF"
}

#### Refrigerator door
Refrigerator door property has only GET method that returns refrigerator door status.

**GET method**
After executing GET method we receive following response:
{
    "refrigerator-door": "CLOSED"
} 
#### Freezer door
Freezer door property has only GET method that return freezer door status.

**GET method**
After executing GET method we receive following response:
{
    "freezer-door": "CLOSED"
}

#### Refrigerator temperature
Refrigerator temperature property has GET method that returns refrigerator temperature in Celsius and PUT method that change refrigerator temperature.

**GET method**
After executing GET method we receive following response:
{
    "refrigerator-temperature": 5
} 

**PUT method**
For PUT method request we need to add following JSON:
{
    "refrigerator-temperature": 4
} 

**Parameters**
* refrigerator-temperature: (integer), possible values: in the range from 3 to 8 Celsius.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Freezer temperature
Freezer temperature property has GET method that returns freezer temperature in Celsius and PUT method that change freezer temperature.

**GET method**
After executing GET method we receive following response:
{
    "freezer-temperature": -22
} 

**PUT method**
For PUT method request we need to add following JSON:
{
    "freezer-temperature": -18
} 

**Parameters**
* freezer-temperature: (integer), possible values: in the range from -24 to -16 Celsius.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}

#### Fastfreeze
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
Childlock property has GET method that returns child lock status and PUT method that change child lock status.

**GET method**
After executing GET method we receive following response:
{
    "child-lock": "ON"
}

**PUT method**
For PUT method request we need to add following JSON:
{
    "child-lock": "OFF"
}

**Parameters**
* child-lock: (string), possible values: ON and OFF.

**Return**
After executing PUT method we receive following response:
{
    "result": "true"
}
