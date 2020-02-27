IDRSolutions C# Client with JPedal
======================================

Convert PDF to Images with C#, using the IDRSolutions C# Client to
interact with IDRsolutions' `JPedal Microservice Example`_.

The JPedal Microservice Example is an open source project that allows you to
convert PDF to Images by running `JPedal`_ as an online service.

IDR Solutions offer a free trial service for running JPedal with C#,
more infomation on this can be found `here.`_

--------------

Installation
------------

Using Nuget:
~~~~~~~~~~~~

::

    $ nuget install idrsolutions_csharp_client


--------------

Usage
-----

Basic:
~~~~~~

First, import IDRCloudClient and setup the converter details by creating a new
``IDRCloudClient`` object :

::

    using idrsolutions_csharp_client;
	IDRCloudClient client = new IDRCloudClient('http://localhost:8080/' + IDRCloudClient.JPEDAL);


Next you need to create the conversion parameters :

::

	Dictionary<string, string> parameters = new Dictionary<string, string>
	{
		["input"] = IDRCloudClient.UPLOAD,
		["file"] = "path/to/input.pdf"
	};


Alternatively, you can specify a url from which the server will download the 
file to convert.

::

	Dictionary<string, string> parameters = new Dictionary<string, string>
	{
		["input"] = IDRCloudClient.DOWNLOAD,
		["url"] = "http://link.to/filename"
	};


Finally you can perform the conversion and download the results with the following : 

::

	// conversionResults are the values from the servers response
	Dictionary<string, string> conversionResults = client.Convert(parameters);

	// You can also specify a directory to download the converted output to:
	client.DownloadResult(conversionResults, "path/to/output/dir");


Additional parameters can be used in ``convert()``, they are defined in our
`API`_

--------------

Changes for docker version
--------------------------

If your JPedal service requires authentication, you can set the username and password by passing an additional tuple argument as shown below:
::

    using idrsolutions_csharp_client;
    client = IDRCloudClient("http://localhost:8080/" + IDRCloudClient.JPEDAL, "username", "password")


--------------

Who do I talk to?
=================

Found a bug, or have a suggestion / improvement? Let us know through the
Issues page.

Got questions? You can contact us `here`_.

--------------

Code of Conduct
===============

Short version: Don't be an awful person.

Longer version: Everyone interacting in the IDRSolutions C# Client
project's codebases, issue trackers, chat rooms and mailing lists is
expected to follow the `code of conduct`_.

--------------

Copyright 2020 IDRsolutions

Licensed under the Apache License, Version 2.0 (the "License"); you may
not use this file except in compliance with the License. You may obtain
a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

.. _JPedal Microservice Example: https://github.com/idrsolutions/jpedal-microservice-example
.. _JPedal: https://www.idrsolutions.com/jpedal/
.. _here: https://idrsolutions.zendesk.com/hc/en-us/requests/new
.. _code of conduct: CODE_OF_CONDUCT.md
.. _API: https://github.com/idrsolutions/jpedal-microservice-example/blob/master/API.md
.. _here.: https://www.idrsolutions.com/jpedal/convert-pdf-in-c-sharp/
