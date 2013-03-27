# Buzz Kill Extension

This Visual Studio Extension goes through the 4 possible Game Controllers (using [SlimDX](http://slimdx.org/)) and reset their rumble to 0.

## Install

Simply open the `BuzzKill.vsix` file and it should install the Extension to your available Visual Studio installations.

## Disable / Remove

From Visual Studio, open `Tools > Extension Manager...` and locate `Buzz Kill`. On the right, you will see buttons to either Disable or Uninstall the Extension.

## Build and Dependencies

The Extension is using [SlimDX](http://slimdx.org/) to reset the rumble. I did not provide all the files to build a VSPackage, only the most important one. If you need to modify it for some reason and build a complete VSPackage, you will need the [VSPackage Builder Extension](http://visualstudiogallery.msdn.microsoft.com/e9f40a57-3c9a-4d61-b3ec-1640c59549b3) and the [Visual Studio 2010 SDK](http://www.microsoft.com/en-us/download/details.aspx?id=2680). If you are using SP1, you will need the [Visual Studio 2010 SP1 SDK](http://www.microsoft.com/en-us/download/details.aspx?id=21835).

I did not try the Extension under 2012.

# Donations

If the Extension is useful to you, consider [buying me a beer ;)](http://www.ericmartel.com/buzz-kill/)

# License

All of the Buzz Kill Extension is licensed under the MIT license.

Copyright (c) 2013 Eric Martel <emartel@gmail.com> http://www.ericmartel.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.