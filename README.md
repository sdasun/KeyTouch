KeyTouch
========

KeyTouch is a Free IME (Input Method Editor) written for Microsoft Windows. Though it was originally created for Sinhala Script, You can edit key layouts by creating xml files for any language or script.


Download
========

https://github.com/sdasun/KeyTouch/blob/master/Binaries/KeyTouch-1.1.exe?raw=true

System Requirements
===================

KeyTouch will run on any PC running Microsoft Windows 2000 or later. If you’re running one of the following operating systems, you’re fine to run KeyTouch:

Windows 7 (all editions, including 64-bit)

Windows Vista (all editions, including 64-bit)

Windows XP (Home, Professional, Media Center, Tablet Edition, 64-bit, .net framework required)

Windows 2003 and 2008 Server (all editions, .net framework required)


Installable Keyboard Layouts – (for Keyboard Layout Designers)
===============================================================

KeyTouch has ability to install a new Unicode keyboard layout xml file.

XML DTD
XML keyboards must follow the XML DTD (Document Type Definition) below:

	<!ELEMENT action ( keySequence*,keySequenceRng* ) >
	
	<!ELEMENT altGrKeyMap ( key* ) >
	
	<!ELEMENT capsAndShiftKeyMap ( key* ) >
	
	<!ELEMENT capsKeyMap (key*) >
	
	<!ELEMENT defaultKeyMap (key*) >
	
	<!ELEMENT key EMPTY >
	<!ATTLIST key code NMTOKEN #REQUIRED >
	<!ATTLIST key output CDATA #REQUIRED >
	<!ATTLIST key state NMTOKEN #IMPLIED >
	
	<!ELEMENT keySequence EMPTY >
	<!ATTLIST keySequence input NMTOKEN #REQUIRED >
	<!ATTLIST keySequence newState NMTOKEN #IMPLIED >
	<!ATTLIST keySequence output CDATA #REQUIRED >
	<!ATTLIST keySequence state NMTOKEN #REQUIRED >
	
	<!ELEMENT keySequenceRng EMPTY >
	<!ATTLIST keySequenceRng end NMTOKEN #REQUIRED >
	<!ATTLIST keySequenceRng newState NMTOKEN #IMPLIED >
	<!ATTLIST keySequenceRng output CDATA #REQUIRED >
	<!ATTLIST keySequenceRng start NMTOKEN #REQUIRED >
	<!ATTLIST keySequenceRng state NMTOKEN #REQUIRED >
	
	<!ELEMENT layout (defaultKeyMap, shiftKeyMap, capsKeyMap, capsAndShiftKeyMap, altGrKeyMap, action ) >
	<!ATTLIST layout createdby CDATA #REQUIRED >
	<!ATTLIST layout info CDATA #REQUIRED >
	<!ATTLIST layout name NMTOKEN #REQUIRED >
	<!ATTLIST layout version NMTOKEN #REQUIRED >
	
	<!ELEMENT shiftKeyMap ( key* ) >


A keyboard layout description is a standard XML file, and also follows the XML specifications. The text file encoding should be Unicode UTF-8

	<layout> Element
<b>The root element is &lt;layout&gt; , &lt;layout&gt; has following attributes, all are required.</b>

	name: Name of keyboard kayout. 
		This will be appear in keyboard layout list on KeyTouch configuration page.
	version: Version number of the keyboard.
	info: Detailed information about keylayout. 
		This wll be appear under Detail on configuration page.
	createdby: Creater of the keyboard layout.
