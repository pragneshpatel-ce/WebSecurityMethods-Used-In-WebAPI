# WebSecurityMethods-Used-In-WebAPI
On WebAPI websecurity class does not exist by default, so we could configure them in to WebAPI project.

=================  For Membership in WebAPI =================

reference :::: https://stackoverflow.com/questions/15753864/to-call-this-method-the-membership-provider-property-must-be-an-instance-of/15754808#15754808

1.  add in to web.config file -->  <system.web> in that quotes add roleManager, membership, sessionState quotes. You can view in web.config file section.


2.  install package using package manager consol :

PM> Install-Package Microsoft.AspNet.WebPages.WebData
