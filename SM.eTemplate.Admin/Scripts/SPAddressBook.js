//for setting forcus for image or  <a> tag.
 function ImgSetfocus(id) 
 {
	var obj = document.getElementById(id);
	if(obj != null)
    {
		imgObj = obj;
 	}
 }
  
/////////////////////////////////////////////////
function SPAddressBook(clientID)
{
	this.ClientID = clientID;
	var field = document.getElementById(clientID);	
	this.AttachEventEx(field, "onpropertychange", this.OnChangeHandler);
	/*
	this.ClientID = clientID;	
	
	var oInstance = this;
	
	var field = document.getElementById(this.ClientID);
	if (field.attachEvent)
	{
		field.attachEvent("onkeypress",  this.KeyPressHandler);
		//field.attachEvent("onblur",  this.OnBlurHandler);
	}
	else
	{
		field.addEventListener("onkeypress", this.KeyPressHandler , false);
		//field.addEventListener("onblur",  this.OnBlurHandler, false);
	}
	
	this.AttachEventEx(field, "onpropertychange", this.OnChangeHandler);
	*/
}

SPAddressBook.prototype.AttachEventEx = function(element, eventName, handler)
{
	eventName = this.FixEventName(eventName);
	if (element.addEventListener)
	{
		element.addEventListener(eventName, handler, false);
	}
	else if (element.attachEvent)
	{	
		element.attachEvent(eventName, handler);
	}
};

SPAddressBook.prototype.DetachEventEx = function (element, eventName, handler)
{
	eventName = this.FixEventName(eventName);
	if (element.addEventListener)
	{
		element.removeEventListener(eventName, handler, false);
	}
	else if (element.detachEvent)
	{
		element.detachEvent(eventName, handler);
	}
};

SPAddressBook.prototype.FixEventName = function (eventName)
{
	eventName = eventName.toLowerCase();
	if (document.addEventListener)
	{		
		if (this.StartsWith(eventName, "on")) return eventName.substr(2);
		else return eventName;
	}
	else if (document.attachEvent && !this.StartsWith(eventName, "on"))
	{
		return "on" + eventName;
	}
	else
	{
		return eventName;
	}
};

SPAddressBook.prototype.StartsWith = function (text, value)
{
	if (typeof(value) != "string") return false;		
	return (0 == text.indexOf(value));
};
 
SPAddressBook.prototype.FixEventName = function (eventName)
{
	eventName = eventName.toLowerCase();
	if (document.addEventListener)
	{		
		if (this.StartsWith(eventName, "on")) return eventName.substr(2);
		else return eventName;
	}
	else if (document.attachEvent && !this.StartsWith(eventName, "on"))
	{
		return "on" + eventName;
	}
	else
	{
		return eventName;
	}
};
SPAddressBook.prototype.FireEvent = function(handler, oldValue, newValue) 
{
	if (!handler)
		return true;
	
	FirstParam = oldValue;
	SecondParam = newValue;	
	
	var s = handler;
	s = s + "(this, FirstParam";	
	s = s + ",SecondParam";
	s = s + ");";
			
	return eval(s);
};



SPAddressBook.prototype.Instance = function()
{	
	var addrBook = window[this.ClientID + "_Object"];
	
	return addrBook;
}
SPAddressBook.prototype.Initialize = function (configObject)
{	
	this.LoadConfiguration(configObject);
};
SPAddressBook.prototype.LoadConfiguration = function (configObject)
{
    for (var property in configObject)
    {		
        this[property] = configObject[property];
    } 
};

SPAddressBook.prototype.ClearAdd = function()
{
	var field = document.getElementById(this.ClientID);
	field.value = "";	
}
SPAddressBook.prototype.GetUser = function()
{
	var field = document.getElementById(this.ClientID);
	return field.value;	
}
//Added by VuongNK 20070525
SPAddressBook.prototype.GetUserInfor = function()
{
	var field = document.getElementById(this.ClientID + "_FullInformation");
	return field.value;
}
//end Added by VuongNK

SPAddressBook.prototype.SetUser = function(user)
{
	var field = document.getElementById(this.ClientID);
	field.value = user;	
}
SPAddressBook.prototype.SetFocus = function()
{
	//var field = document.getElementById(this.ClientID);
	var field = this.TextBox;
	if(field && !field.disabled)
	{
		field.focus();
		field.select();
	}
}
SPAddressBook.prototype.FireEvent = function(handler, oldValue, newValue) 
{
	if (!handler)
		return true;
	
	FirstParam = oldValue;
	SecondParam = newValue;	
	
	var s = handler;
	s = s + "(this, FirstParam";	
	s = s + ",SecondParam";
	s = s + ");";
			
	return eval(s);
};
SPAddressBook.prototype.HandleOnPaste = function()
{	
	var oEvent = window.event;	
	var addrBook = window[oEvent.srcElement.id + "_Object"];
								
	if(addrBook.Editable == false)
	{   
		addrBook.PreventDefault();
	}
}
SPAddressBook.prototype.OnBlurHandler = function()
{
	var oEvent = window.event;	
	var addrBook = window[oEvent.srcElement.id + "_Object"];
	
	var fieldValue = addrBook.GetUser();
		
	addrBook.RaiseOnClientTextChanged(addrBook.OldValue, fieldValue);	
}

SPAddressBook.prototype.KeyPressHandler = function()
{	
	var oEvent = window.event;	
	var addrBook = window[oEvent.srcElement.id + "_Object"];
	
	var fieldValue = addrBook.GetUser();	
				
	if(addrBook.MultiSelect == false)
	{
		//Not allow user input ";" or "," when MultiSelect = false		
		if(oEvent.keyCode == 59 || oEvent.keyCode == 44)
		{
			addrBook.PreventDefault();
		}
	}

	switch(oEvent.keyCode)
	{				
		case 13:
			//Raise client event
			addrBook.RaiseOnClientTextChanged(addrBook.OldValue, fieldValue);			
			addrBook.PreventDefault();
			break;
		
	}
}
//Return Display values
SPAddressBook.prototype.GetDisplayValue = function(oldValue,addrBook)
{
	var strUserInfors = oldValue.split(';');
	var strDisplayValue = "";
	var i;
	for(i = 0;i < strUserInfors.length;i++)
	{
		if (strUserInfors[i] != "")
			strDisplayValue += strUserInfors[i].split(',')[addrBook.DisplayMode] + ";";
	}
	if((strDisplayValue != null))
	{
		var i = strDisplayValue.lastIndexOf(";");
		if ( i >= 0)
			return strDisplayValue.substring(0,i);
		else
			return strDisplayValue;
	}
	else
		return "";	
}

SPAddressBook.prototype.OnChangeHandler = function()
{	
	var oEvent = window.event;	
	var addrBook = window[oEvent.srcElement.id + "_Object"];
	var textBoxField = document.getElementById(addrBook.ClientID);		
	
	var fieldValue = addrBook.GetUser();		
	//if display mode is Display Name and Full Information 
	// VuongNK - Start
	if(addrBook.ReturnType == 5)
	{
		//Remove OnChangeHandler event			
		addrBook.DetachEventEx(textBoxField, "onpropertychange", addrBook.OnChangeHandler);
			
		var displayValue = addrBook.GetDisplayValue(fieldValue,addrBook);
		
		document.getElementById(addrBook.ClientID).value = displayValue;
					
		//Add event again			
		addrBook.AttachEventEx(textBoxField, "onpropertychange", addrBook.OnChangeHandler);
		
		//Save display name and login name into hidden field
		var hiddFullInfor = document.getElementById(addrBook.ClientID + "_FullInformation");
		
		if(hiddFullInfor)
		{
			hiddFullInfor.value = fieldValue;
		}		
		
	}
	
	// VuongNK - End
	
	addrBook.RaiseOnClientTextChanged(addrBook.OldValue, fieldValue);
}
SPAddressBook.prototype.RaiseOnClientTextChanged = function(oldValue, newValue)
{
	if( (newValue.length > 0) && (this.Trim(newValue) != this.Trim(oldValue)) )
	{		
		this.FireEvent(this.OnClientTextChanged, oldValue, newValue);
		this.OldValue = newValue;
	}
}
SPAddressBook.prototype.PreventDefault = function()
{
	var eventArgs = window.event;
	if (eventArgs.preventDefault)
	{
		eventArgs.preventDefault();
	}
	else
	{
		eventArgs.returnValue = false;
		eventArgs.cancel = true;
	}
};
SPAddressBook.prototype.RequiredValidate = function(msg)
{
	var isValid = true;		
	
	//Get AddressBook object
	var addrBook = this.Instance();
	
	var value = addrBook.GetUser();
	
	if( this.BlankString(value))
	{		
		isValid = false;
	}
		
	if(!isValid)
	{
		this.SetFocus();
			
		window.alert(msg);
	}	
	return isValid;
}
SPAddressBook.prototype.MultiValueAddressBookValidate = function(msg)
{
	var bMultiSelect;
	var iNumber;
	var isValid = true;
				
	//Get AddressBook object	
	var addrBook = this.Instance();				
		
	bMultiSelect = addrBook.MultiSelect;
		
	if(bMultiSelect == true)
	{		
		iNumber = 2;
	}
	else
	{	
		iNumber = 1;
	}
		
	var value = addrBook.GetUser();
	isValid = this.MultiValueValidation(value, iNumber);
		
	if(!isValid)
	{
		if(msg == null || msg.length ==0)
		{
			if(this.ReturnType != 1)
				msg = "Pls input only one email";
			else
				msg = "Pls input only one user";
		}
		window.alert(msg);
		
		this.SetFocus();
	}
	
	return isValid;
}
SPAddressBook.prototype.MultiValueValidation = function(value, iNumber)
{	
	if(value != null || value != undefined)
	{			
		var str = value;				
						
		if(iNumber == 1)
		{
			var len = str.indexOf(";");					
			if(len != -1)
			{
				return false;				
			}
			else
			{
				len = str.indexOf(",");
				if(len != -1)
				{
					return false;
				}
			}					
		}
	}
	return true;
}
SPAddressBook.prototype.MailValidation = function(msg)
{	
	var isValid = true;
	var filter=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
		
	if(this.ReturnType != 1)
		return true;
		
	var field = document.getElementById(this.ClientID);	
	var value = field.value;
	
	if(value != null || value != undefined)
	{	
				
		var str = value.split(this.Seperator);
		
		for(var i=0;i<str.length;i++)
		{
			if (!filter.test(str))
			{				
				isValid = false;
				break;
			}
		}
		
	}
	else
	{
		isValid = false;
	}
	
	if(!isValid)
	{
		if(msg == null || msg.length ==0)
		{
			msg = "Pls input a valid mail address.";
		}
		window.alert(msg);
		
		this.SetFocus();
	}
	
	return isValid;
}
SPAddressBook.prototype.BlankString = function(st)
{
			
	st = st.toString();

	st = st.replace(/\s/g, "");
	return (st == "");
}

SPAddressBook.prototype.Trim = function( str )
{
	var start;
	var end;
	if(!str)
		return;
	str = str.toString();
	var len = str.length;
	for (start = 0; start < len; start ++)
	{
		ch = str.charAt(start);
		if (ch!=' ' && ch!='\t' && ch!='\n' && ch!='\r' && ch!='\f')
			break;
	}
	if (start == len)
		return "";
	for (end = len - 1; end > start; end --)
	{
		ch = str.charAt(end);
		if (ch!=' ' && ch!='\t' && ch!='\n' && ch!='\r' && ch!='\f')
			break;
	}
	end ++;
	return str.substring(start, end);
}
function ShowAddressBook(clientID)
{
	var addrBook = window[clientID + "_Object"];
	if(!addrBook)
	{
		return;
	}
	
	var field = document.getElementById(clientID);
	var seperator = addrBook.Seperator;			
	
	//Added to prevent onclick when SPAddressBook is readonly	
	if(field.disabled || addrBook.Editable == false )
	{		
		return;
	}		
		
	CallSPAddressBook(clientID);		
}

var SPAddressWindow = null;

function CallSPAddressBook(clientID)
{ 
	var addrBook = window[clientID + "_Object"];
	if(!addrBook)
	{
		return;
	}
	var openOption;
	var mode;
	var width;
	var height;
	
	// Generate unique window name
	var abWindowName = Math.random();		
	abWindowName = abWindowName + "";
	abWindowName = abWindowName.substring(2);	
	
	//Get selected user
	var selUsers="";
	if(addrBook.ReturnType == "5")
	{
	    selUsers = addrBook.GetUserInfor();
	}
	else
	{
	    selUsers = addrBook.GetUser();
	}
	
	selUsers = selUsers.replace(/; /g,";");
	
	if(SPAddressWindow)
	{
		SPAddressWindow.close();		
	}
	
	//Select single values
	if(addrBook.MultiSelect == false)
	{
		mode = 0;
		openOption = 'scrollbars=0,menubar=0,resizable=0,status=0,width=350,height=385,left='+ (screen.width / 2 - 270/ 2) + ',top=' + (screen.height / 2 - 400/ 2);
	}
	//Select mutiple values
	else
	{	
		mode = 1;
		openOption = 'menubar=0,resizable=0,status=0,scrollbars=0,width=600,height=385,left='+ (screen.width / 2 - 600/ 2) + ',top=' + (screen.height / 2 - 400/ 2);
    }
    
    SPAddressWindow = window.open(addrBook.CurrentSiteUrl + '?controlID=' + escape(clientID) + '&sourcetype=' + addrBook.SourceType + '&mode=' + mode + '&returnValue=' + addrBook.ReturnType + '&selUsers=' + selUsers, abWindowName, openOption);
	if(SPAddressWindow) {		
		SPAddressWindow.focus();
	}
}
