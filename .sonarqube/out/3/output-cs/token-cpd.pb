˜
oC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\Attributes\PermissionAttribute.cs
	namespace 	
CustomFramework
 
. 
Authorization '
.' (

Attributes( 2
{ 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Class% *
|+ ,
AttributeTargets- =
.= >
Method> D
,D E
AllowMultipleF S
=T U
trueV Z
)Z [
][ \
public 

class 
PermissionAttribute $
:% &
AuthorizeAttribute' 9
{		 
public

 
string

 
Entity

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
string 
CustomClaim !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
Crud 
? 
Crud 
{ 
get 
;  
set! $
;$ %
}& '
public 
PermissionAttribute "
(" #
string# )
customClaim* 5
)5 6
:7 8
base9 =
(= >
$str> J
)J K
{ 	
CustomClaim 
= 
customClaim %
;% &
} 	
public 
PermissionAttribute "
(" #
string# )
entity* 0
,0 1
Crud2 6
crud7 ;
); <
:= >
base? C
(C D
$strD P
)P Q
{ 	
Entity 
= 
entity 
; 
Crud 
= 
crud 
; 
} 	
} 
} È
~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\Attributes\PermissionAuthorizationRequirement.cs
	namespace 	
CustomFramework
 
. 
Authorization '
.' (

Attributes( 2
{ 
public 

class .
"PermissionAuthorizationRequirement 3
:4 5%
IAuthorizationRequirement6 O
{ 
} 
}		 ×
jC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\CustomAuthorizationPolicy.cs
	namespace 	
CustomFramework
 
. 
Authorization '
{ 
public 

class %
CustomAuthorizationPolicy *
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public		 
IList		 
<		 %
IAuthorizationRequirement		 .
>		. /%
AuthorizationRequirements		0 I
{		J K
get		L O
;		O P
set		Q T
;		T U
}		V W
}

 
} È
[C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\Enums\Crud.cs
	namespace 	
CustomFramework
 
. 
Authorization '
.' (
Enums( -
{ 
public 

enum 
Crud 
{ 
Create 
, 
Update 
, 
Delete 
, 
Select 
}		 
}

 é
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\Extensions\AuthorizationServiceExtensions.cs
	namespace 	
CustomFramework
 
. 
Authorization '
.' (

Extensions( 2
{ 
public 

static 
class *
AuthorizationServiceExtensions 6
{ 
public		 
static		 
IServiceCollection		 ("
AddCustomAuthorization		) ?
(		? @
this		@ D
IServiceCollection		E W
services		X `
,		` a
IList		b g
<		g h&
CustomAuthorizationPolicy			h 
>
		 ‚#
authorizationPolicies
		ƒ ˜
)
		˜ ™
{

 	
services 
. 
AddAuthorization %
(% &
options& -
=>. 0
{ 
foreach 
( 
var 
authorizationPolicy 0
in1 3!
authorizationPolicies4 I
)I J
{ 
options 
. 
	AddPolicy %
(% &
authorizationPolicy& 9
.9 :
Name: >
,> ?
policyBuilder@ M
=>N P
{ 
foreach 
(  !
var! $$
authorizationRequirement% =
in> @
authorizationPolicyA T
.T U%
AuthorizationRequirementsU n
)n o
{ 
policyBuilder %
.% &
Requirements& 2
.2 3
Add3 6
(6 7$
authorizationRequirement7 O
)O P
;P Q
} 
} 
) 
; 
} 
} 
) 
; 
return 
services 
; 
} 	
} 
} ã
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\Extensions\JwtAuthenticationServiceExtension.cs
	namespace 	
CustomFramework
 
. 
Authorization '
.' (

Extensions( 2
{		 
public

 

static

 
class

 -
!JwtAuthenticationServiceExtension

 9
{ 
public 
static 
IServiceCollection ( 
AddJwtAuthentication) =
(= >
this> B
IServiceCollectionC U
servicesV ^
,^ _
string` f
validAudienceg t
,t u
stringv |
validIssuer	} ˆ
,
ˆ ‰
string
Š 
issuerSigningKey
‘ ¡
)
¡ ¢
{ 	
services 
. 
AddAuthentication &
(& '
options' .
=>/ 1
{ 
options 
.  %
DefaultAuthenticateScheme  9
=: ;
JwtBearerDefaults< M
.M N 
AuthenticationSchemeN b
;b c
options 
.  "
DefaultChallengeScheme  6
=7 8
JwtBearerDefaults9 J
.J K 
AuthenticationSchemeK _
;_ `
} 
) 
. 
AddJwtBearer 
( 
options %
=>& (
{ 
options 
. %
TokenValidationParameters 5
=6 7
new8 ;%
TokenValidationParameters< U
{ 
ValidateAudience (
=) *
true+ /
,/ 0
ValidAudience %
=& '
validAudience( 5
,5 6
ValidateIssuer &
=' (
true) -
,- .
ValidIssuer #
=$ %
validIssuer& 1
,1 2
ValidateLifetime (
=) *
true+ /
,/ 0$
ValidateIssuerSigningKey 0
=1 2
true3 7
,7 8
IssuerSigningKey (
=) *
new+ . 
SymmetricSecurityKey/ C
(C D
Encoding $
.$ %
UTF8% )
.) *
GetBytes* 2
(2 3
issuerSigningKey3 C
)C D
)D E
}   
;   
options"" 
."" 
Events"" "
=""# $
new""% (
JwtBearerEvents"") 8
{## 
OnTokenValidated$$ (
=$$) *
ctx$$+ .
=>$$/ 1
Task$$2 6
.$$6 7
CompletedTask$$7 D
,$$D E"
OnAuthenticationFailed%% .
=%%/ 0
ctx%%1 4
=>%%5 7
{&& 
Console'' #
.''# $
	WriteLine''$ -
(''- .
$str''. >
,''> ?
ctx''@ C
.''C D
	Exception''D M
.''M N
Message''N U
)''U V
;''V W
return(( "
Task((# '
.((' (
CompletedTask((( 5
;((5 6
})) 
}** 
;** 
}++ 
)++ 
;++ 
return.. 
services.. 
;.. 
}// 	
}00 
}11 ê
wC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\Handlers\AttributeAuthorizationHandler.cs
	namespace

 	
CustomFramework


 
.

 
Authorization

 '
.

' (
Handlers

( 0
{ 
public 

abstract 
class )
AttributeAuthorizationHandler 7
<7 8
TRequirement8 D
,D E

TAttributeF P
>P Q
:R S 
AuthorizationHandlerT h
<h i
TRequirementi u
>u v
where 
TRequirement 
: %
IAuthorizationRequirement 6
where 

TAttribute 
: 
	Attribute $
{ 
	protected 
override 
Task "
HandleRequirementAsync  6
(6 7'
AuthorizationHandlerContext7 R
contextS Z
,Z [
TRequirement\ h
requirementi t
)t u
{ 	
var 

attributes 
= 
new  
List! %
<% &

TAttribute& 0
>0 1
(1 2
)2 3
;3 4
if 
( 
! 
( 
( 
context 
. 
Resource #
as$ &&
AuthorizationFilterContext' A
)A B
?B C
.C D
ActionDescriptorD T
isU W&
ControllerActionDescriptorX r
action 
) 
) 
return "
HandleRequirementAsync  6
(6 7
context7 >
,> ?
requirement@ K
,K L

attributesM W
)W X
;X Y

attributes 
. 
AddRange 
(  
GetAttributes  -
(- .
action. 4
.4 5
ControllerTypeInfo5 G
.G H 
UnderlyingSystemTypeH \
)\ ]
)] ^
;^ _

attributes 
. 
AddRange 
(  
GetAttributes  -
(- .
action. 4
.4 5

MethodInfo5 ?
)? @
)@ A
;A B
return "
HandleRequirementAsync )
() *
context* 1
,1 2
requirement3 >
,> ?

attributes@ J
)J K
;K L
} 	
	protected 
abstract 
Task "
HandleRequirementAsync  6
(6 7'
AuthorizationHandlerContext7 R
contextS Z
,Z [
TRequirement\ h
requirementi t
,t u
IEnumerable 
< 

TAttribute "
>" #

attributes$ .
). /
;/ 0
private   
static   
IEnumerable   "
<  " #

TAttribute  # -
>  - .
GetAttributes  / <
(  < =$
ICustomAttributeProvider  = U

memberInfo  V `
)  ` a
{!! 	
return"" 

memberInfo"" 
."" 
GetCustomAttributes"" 1
(""1 2
typeof""2 8
(""8 9

TAttribute""9 C
)""C D
,""D E
false""F K
)""K L
.""L M
Cast""M Q
<""Q R

TAttribute""R \
>""\ ]
(""] ^
)""^ _
;""_ `
}## 	
}$$ 
}%% å
[C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.Authorization\JwtManager.cs
	namespace 	
CustomFramework
 
. 
Authorization '
{		 
public

 

static

 
class

 

JwtManager

 "
{ 
public 
static 
string 
GenerateToken *
(* +
List+ /
</ 0
Claim0 5
>5 6
claims7 =
,= >
string? E
keyF I
,I J
stringK Q
issuerR X
,X Y
stringZ `
audiencea i
,i j
outk n
DateTimeo w
expireDateTime	x †
,
† ‡
int
ˆ ‹
expireInminutes
Œ ›
=
œ 
$num
ž  
)
  ¡
{ 	
SecurityKey 
securityKey #
=$ %
new& ) 
SymmetricSecurityKey* >
(> ?
Encoding? G
.G H
UTF8H L
.L M
GetBytesM U
(U V
keyV Y
)Y Z
)Z [
;[ \
expireDateTime 
= 
DateTime %
.% &
UtcNow& ,
., -

AddMinutes- 7
(7 8
expireInminutes8 G
)G H
;H I
var 
securityToken 
= 
new  #
JwtSecurityToken$ 4
(4 5
issuer 
: 
issuer 
, 
audience 
: 
audience "
," #
claims 
: 
claims 
, 
expires 
: 
expireDateTime '
,' (
signingCredentials "
:" #
new$ '
SigningCredentials( :
(: ;
securityKey; F
,F G
SecurityAlgorithmsH Z
.Z [

HmacSha256[ e
)e f
) 
; 
var 
token 
= 
new #
JwtSecurityTokenHandler 3
(3 4
)4 5
.5 6

WriteToken6 @
(@ A
securityTokenA N
)N O
;O P
return 
token 
; 
} 	
} 
} 