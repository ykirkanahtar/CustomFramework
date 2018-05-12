≈C
kC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Business\BaseBusinessManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Business& .
{ 
public 

abstract 
class 
BaseBusinessManager -
{ 
	protected 
readonly 
ILogger "
<" #
BaseBusinessManager# 6
>6 7
Logger8 >
;> ?
	protected 
readonly 
IMapper "
Mapper# )
;) *
	protected 
BaseBusinessManager %
(% &
ILogger& -
<- .
BaseBusinessManager. A
>A B
loggerC I
,I J
IMapperK R
mapperS Y
)Y Z
{ 	
Logger 
= 
logger 
; 
Mapper 
= 
mapper 
; 
} 	
	protected 
async 
Task 
< 
T 
>  
CommonOperationAsync  4
<4 5
T5 6
>6 7
(7 8
Func8 <
<< =
Task= A
<A B
TB C
>C D
>D E
funcF J
,J K
BusinessBaseRequestL _
businessBaseRequest` s
)s t
{ 	
try 
{ 
var 
result 
= 
await "
func# '
.' (
Invoke( .
(. /
)/ 0
;0 1
return 
result 
; 
} 
catch 
( 
	Exception 
ex 
)  
{   
Logger!! 
.!! 
LogError!! 
(!!  
$num!!  !
,!!! "
ex!!# %
,!!% &
$"!!' )
{!!) *#
DefaultResponseMessages!!* A
.!!A B
AnErrorHasOccured!!B S
}!!S T
 - !!T W
{!!W X
ex!!X Z
.!!Z [
Message!![ b
}!!b c
"!!c d
)!!d e
;!!e f
throw"" 
;"" 
}## 
}$$ 	
	protected&& 
async&& 
Task&& 
<&& 
T&& 
>&&  
CommonOperationAsync&&  4
<&&4 5
T&&5 6
>&&6 7
(&&7 8
Func&&8 <
<&&< =
Task&&= A
<&&A B
T&&B C
>&&C D
>&&D E
func&&F J
,''8 9
BusinessBaseRequest'': M
businessBaseRequest''N a
,((8 9
BusinessUtilMethod((: L
businessUtilMethod((M _
,))8 9
string)): @
additionalInfo))A O
)))O P
{** 	
try++ 
{,, 
var-- 
result-- 
=-- 
await-- "
func--# '
.--' (
Invoke--( .
(--. /
)--/ 0
;--0 1
BusinessUtil.. 
... 
Execute.. $
(..$ %
businessUtilMethod..% 7
,..7 8
result..9 ?
,..? @
additionalInfo..A O
)..O P
;..P Q
return00 
result00 
;00 
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33 
Logger44 
.44 
LogError44 
(44  
$num44  !
,44! "
ex44# %
,44% &
$"44' )
{44) *#
DefaultResponseMessages44* A
.44A B
AnErrorHasOccured44B S
}44S T
 - 44T W
{44W X
ex44X Z
.44Z [
Message44[ b
}44b c
"44c d
)44d e
;44e f
throw55 
;55 
}66 
}77 	
	protected99 
T99 
CommonOperation99 #
<99# $
T99$ %
>99% &
(99& '
Func99' +
<99+ ,
T99, -
>99- .
func99/ 3
,:: 
BusinessBaseRequest:: !
businessBaseRequest::" 5
,;; 
BusinessUtilMethod;;  
businessUtilMethod;;! 3
,<< 
string<< 
additionalInfo<< #
)<<# $
{== 	
try>> 
{?? 
var@@ 
result@@ 
=@@ 
func@@ !
.@@! "
Invoke@@" (
(@@( )
)@@) *
;@@* +
BusinessUtilAA 
.AA 
ExecuteAA $
(AA$ %
businessUtilMethodAA% 7
,AA7 8
resultAA9 ?
,AA? @
additionalInfoAAA O
)AAO P
;AAP Q
returnCC 
resultCC 
;CC 
}DD 
catchEE 
(EE 
	ExceptionEE 
exEE 
)EE  
{FF 
LoggerGG 
.GG 
LogErrorGG 
(GG  
$numGG  !
,GG! "
exGG# %
,GG% &
$"GG' )
{GG) *#
DefaultResponseMessagesGG* A
.GGA B
AnErrorHasOccuredGGB S
}GGS T
 - GGT W
{GGW X
exGGX Z
.GGZ [
MessageGG[ b
}GGb c
"GGc d
)GGd e
;GGe f
throwHH 
;HH 
}II 
}JJ 	
	protectedMM 
asyncMM 
TaskMM 
<MM 
TMM 
>MM /
#CommonOperationWithTransactionAsyncMM  C
<MMC D
TMMD E
>MME F
(MMF G
FuncMMG K
<MMK L
TaskMML P
<MMP Q
TMMQ R
>MMR S
>MMS T
funcMMU Y
,MMY Z
BusinessBaseRequestMM[ n 
businessBaseRequest	MMo Ç
)
MMÇ É
{NN 	
usingOO 
(OO 
varOO 
scopeOO 
=OO 
newOO "
TransactionScopeOO# 3
(OO3 4+
TransactionScopeAsyncFlowOptionOO4 S
.OOS T
EnabledOOT [
)OO[ \
)OO\ ]
{PP 
tryQQ 
{RR 
varSS 
resultSS 
=SS  
awaitSS! &
funcSS' +
.SS+ ,
InvokeSS, 2
(SS2 3
)SS3 4
;SS4 5
scopeTT 
.TT 
CompleteTT "
(TT" #
)TT# $
;TT$ %
returnUU 
resultUU !
;UU! "
}VV 
catchWW 
(WW 
	ExceptionWW  
exWW! #
)WW# $
{XX 
LoggerYY 
.YY 
LogErrorYY #
(YY# $
$numYY$ %
,YY% &
exYY' )
,YY) *
$"YY+ -
{YY- .#
DefaultResponseMessagesYY. E
.YYE F
AnErrorHasOccuredYYF W
}YYW X
 - YYX [
{YY[ \
exYY\ ^
.YY^ _
MessageYY_ f
}YYf g
"YYg h
)YYh i
;YYi j
throwZZ 
;ZZ 
}[[ 
}\\ 
}]] 	
	protected__ 
async__ 
Task__ /
#CommonOperationWithTransactionAsync__ @
(__@ A
Func__A E
<__E F
Task__F J
>__J K
func__L P
,__P Q
BusinessBaseRequest__R e
businessBaseRequest__f y
)__y z
{`` 	
tryaa 
{bb 
usingcc 
(cc 
varcc 
scopecc  
=cc! "
newcc# &
TransactionScopecc' 7
(cc7 8+
TransactionScopeAsyncFlowOptioncc8 W
.ccW X
EnabledccX _
)cc_ `
)cc` a
{dd 
awaitee 
funcee 
.ee 
Invokeee %
(ee% &
)ee& '
;ee' (
scopeff 
.ff 
Completeff "
(ff" #
)ff# $
;ff$ %
}gg 
}hh 
catchii 
(ii 
	Exceptionii 
exii 
)ii  
{jj 
Loggerkk 
.kk 
LogErrorkk 
(kk  
$numkk  !
,kk! "
exkk# %
,kk% &
$"kk' )
{kk) *#
DefaultResponseMessageskk* A
.kkA B
AnErrorHasOccuredkkB S
}kkS T
 - kkT W
{kkW X
exkkX Z
.kkZ [
Messagekk[ b
}kkb c
"kkc d
)kkd e
;kke f
throwll 
;ll 
}mm 
}nn 	
}oo 
}pp é
kC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Business\BaseBusinessRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Business& .
{ 
public 

class 
BusinessBaseRequest $
{ 
public 

MethodBase 

MethodBase $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
}		 Î
hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Business\IBusinessManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Business& .
{ 
public 

	interface 
IBusinessManager %
<% &
TEntity& -
,- .
in/ 1
TCreateRequest2 @
,@ A
inB D
TKeyE I
>I J
whereK P
TEntityQ X
:Y Z
	BaseModel[ d
<d e
TKeye i
>i j
{ 
Task 
< 
TEntity 
> 
CreateAsync !
(! "
TCreateRequest" 0
request1 8
)8 9
;9 :
Task		 
DeleteAsync		 
(		 
TKey		 
id		  
)		  !
;		! "
Task

 
<

 
TEntity

 
>

 
GetByIdAsync

 "
(

" #
TKey

# '
id

( *
)

* +
;

+ ,
} 
} Ä
nC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Business\IBusinessManagerUpdate.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Business& .
{ 
public 

	interface "
IBusinessManagerUpdate +
<+ ,
TEntity, 3
,3 4
in5 7
TUpdateRequest8 F
,F G
inH J
TKeyK O
>O P
where 
TEntity 
: 
	BaseModel !
<! "
TKey" &
>& '
{ 
Task		 
<		 
TEntity		 
>		 
UpdateAsync		 !
(		! "
TKey		" &
id		' )
,		) *
TUpdateRequest		+ 9
request		: A
)		A B
;		B C
}

 
} ˛
pC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Constants\DefaultResponseMessages.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Constants& /
{ 
public 

static 
class #
DefaultResponseMessages /
{ 
public 
const 
string 
SuccessMessage *
=+ ,
$str- 6
;6 7
public 
const 
string 
AnErrorHasOccured -
=. /
$str0 C
;C D
public 
const 
string .
"DuplicateRecordForUniqueValueError >
=? @
$strA e
;e f
public 
const 
string #
UnauthorizedAccessError 3
=4 5
$str6 O
;O P
public		 
const		 
string		 
NotFoundError		 )
=		* +
$str		, ;
;		; <
public

 
const

 
string

 

LoginError

 &
=

' (
$str

) 5
;

5 6
public 
const 
string  
ModelStateValidError 0
=1 2
$str3 I
;I J
public 
const 
string 
ModelStateErrors ,
=- .
$str/ A
;A B
public 
const 
string 
RecordExistsError -
=. /
$str0 C
;C D
public 
const 
string "
ArgumentExceptionError 2
=3 4
$str5 M
;M N
} 
} ö
kC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Constants\ValidatorConstants.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Constants& /
{ 
public 

static 
class 
ValidatorConstants *
{ 
public 
const 
string 
CannotBeNullError -
=. /
$str0 C
;C D
public 
const 
string 
MaxLengthError *
=+ ,
$str- =
;= >
public 
const 
string 
EmailFormatError ,
=- .
$str/ A
;A B
} 
}

 ä
lC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Constants\WebApiUtilConstants.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Constants& /
{ 
public 

static 
class 
WebApiUtilConstants +
{ 
public 
static 
readonly 
string %
DefaultRoute& 2
=3 4
ConfigHelper5 A
.A B!
GetConfigurationValueB W
(W X
$strX r
)r s
??t v
$strw }
;} ~
public		 
static		 
readonly		 
string		 %

AdminRoute		& 0
=		1 2
ConfigHelper		3 ?
.		? @!
GetConfigurationValue		@ U
(		U V
$str		V n
)		n o
??		p r
DefaultRoute		s 
+
		Ä Å
$str
		Ç ä
;
		ä ã
public

 
static

 
readonly

 
int

 "
DefaultListCount

# 3
=

4 5
Convert

6 =
.

= >
ToInt32

> E
(

E F
ConfigHelper

F R
.

R S!
GetConfigurationValue

S h
(

h i
$str	

i á
)


á à
??


â ã
$str


å ê
)


ê ë
;


ë í
} 
} ΩP
dC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Contracts\ApiResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Contracts& /
{ 
public 

class 
ApiResponse 
: 
IApiResponse +
{ 
private 
readonly  
ILocalizationService - 
_localizationService. B
;B C
private 
readonly 
ILogger  
_logger! (
;( )
public 
ApiResponse 
(  
ILocalizationService /
localizationService0 C
,C D
ILoggerE L
loggerM S
)S T
{ 	 
_localizationService  
=! "
localizationService# 6
;6 7
_logger 
= 
logger 
; 
} 	
public 
HttpStatusCode 

StatusCode (
{) *
get+ .
;. /
private0 7
set8 ;
;; <
}= >
[ 	
JsonProperty	 
( 
NullValueHandling '
=( )
NullValueHandling* ;
.; <
Ignore< B
)B C
]C D
public 
string 
Message 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 
object 
Result 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public!! 
int!! 

TotalCount!! 
{!! 
get!!  #
;!!# $
private!!% ,
set!!- 0
;!!0 1
}!!2 3
public## 
ErrorResponse## 
ErrorResponse## *
{##+ ,
get##- 0
;##0 1
set##2 5
;##5 6
}##7 8
public%% 
ApiResponse%% 
Ok%% 
(%% 
object%% $
result%%% +
)%%+ ,
{&& 	

StatusCode'' 
='' 
HttpStatusCode'' '
.''' (
OK''( *
;''* +
Result(( 
=(( 
result(( 
;(( 

TotalCount)) 
=)) 
$num)) 
;)) 
Message** 
=**  
_localizationService** *
.*** +
GetValue**+ 3
(**3 4#
DefaultResponseMessages**4 K
.**K L
SuccessMessage**L Z
)**Z [
;**[ \
_logger,, 
.,, 
LogInformation,, "
(,," #
Message,,# *
,,,* +
Result,,, 2
),,2 3
;,,3 4
return-- 
this-- 
;-- 
}.. 	
public00 
ApiResponse00 
Ok00 
<00 
T00 
>00  
(00  !
IEnumerable00! ,
<00, -
T00- .
>00. /
list000 4
,004 5
int006 9

totalCount00: D
)00D E
{11 	

StatusCode22 
=22 
HttpStatusCode22 '
.22' (
OK22( *
;22* +
Result33 
=33 
list33 
;33 

TotalCount44 
=44 

totalCount44 #
;44# $
Message55 
=55  
_localizationService55 *
.55* +
GetValue55+ 3
(553 4#
DefaultResponseMessages554 K
.55K L
SuccessMessage55L Z
)55Z [
;55[ \
_logger77 
.77 
LogInformation77 "
(77" #
Message77# *
,77* +
Result77, 2
)772 3
;773 4
return88 
this88 
;88 
}99 	
public;; 
ApiResponse;; 
Error;;  
(;;  !
HttpStatusCode;;! /

statusCode;;0 :
,;;: ;
	Exception;;< E
	exception;;F O
);;O P
{<< 	
ErrorResponse== 
=== 
new== 
ErrorResponse==  -
(==- .
	exception==. 7
)==7 8
;==8 9

StatusCode>> 
=>> 

statusCode>> #
;>># $
Message?? 
=?? 
$"?? 
{??  
_localizationService?? -
.??- .
GetValue??. 6
(??6 7#
DefaultResponseMessages??7 N
.??N O
AnErrorHasOccured??O `
)??` a
}??a b
 : ??b e
{??e f*
GetDefaultMessageForException	??f É
(
??É Ñ
	exception
??Ñ ç
)
??ç é
}
??é è
"
??è ê
;
??ê ë
_loggerAA 
.AA 
LogErrorAA 
(AA 
$numAA 
,AA 
	exceptionAA  )
,AA) *
MessageAA+ 2
)AA2 3
;AA3 4
returnBB 
thisBB 
;BB 
}CC 	
publicEE 
ApiResponseEE 
ErrorEE  
(EE  !
HttpStatusCodeEE! /

statusCodeEE0 :
,EE: ;
stringEE< B
messageEEC J
,EEJ K
	ExceptionEEL U
	exceptionEEV _
)EE_ `
{FF 	
ErrorResponseGG 
=GG 
newGG 
ErrorResponseGG  -
(GG- .
	exceptionHH 
)II 
;II 

StatusCodeKK 
=KK 

statusCodeKK #
;KK# $
MessageLL 
=LL 
$"LL 
{LL  
_localizationServiceLL -
.LL- .
GetValueLL. 6
(LL6 7#
DefaultResponseMessagesLL7 N
.LLN O
AnErrorHasOccuredLLO `
)LL` a
}LLa b
 : LLb e
{LLe f*
GetDefaultMessageForException	LLf É
(
LLÉ Ñ
	exception
LLÑ ç
)
LLç é
}
LLé è
{
LLê ë"
_localizationService
LLë •
.
LL• ¶
GetValue
LL¶ Æ
(
LLÆ Ø
message
LLØ ∂
)
LL∂ ∑
}
LL∑ ∏
"
LL∏ π
;
LLπ ∫
_loggerNN 
.NN 
LogErrorNN 
(NN 
$numNN 
,NN 
	exceptionNN  )
,NN) *
MessageNN+ 2
)NN2 3
;NN3 4
returnOO 
thisOO 
;OO 
}PP 	
publicRR 
ApiResponseRR 
ModelStateErrorRR *
(RR* + 
ModelStateDictionaryRR+ ?

modelStateRR@ J
)RRJ K
{SS 	
varTT 
modelstateStringTT  
=TT! "

modelStateTT# -
.TT- .
ModelStateToStringTT. @
(TT@ A 
_localizationServiceTTA U
)TTU V
;TTV W
ErrorResponseWW 
=WW 
newWW 
ErrorResponseWW  -
(WW- .
newXX 
ValidationExceptionXX '
(XX' (
)XX( )
,YY 
modelstateStringYY "
)ZZ 
;ZZ 

StatusCode\\ 
=\\ 
HttpStatusCode\\ '
.\\' (

BadRequest\\( 2
;\\2 3
Message]] 
=]]  
_localizationService]] *
.]]* +
GetValue]]+ 3
(]]3 4#
DefaultResponseMessages]]4 K
.]]K L
ModelStateErrors]]L \
)]]\ ]
;]]] ^
_logger__ 
.__ 
LogError__ 
(__ 
$num__ 
,__ 
Message__  '
)__' (
;__( )
return`` 
this`` 
;`` 
}aa 	
privatecc 
stringcc )
GetDefaultMessageForExceptioncc 4
(cc4 5
	Exceptioncc5 >
	exceptioncc? H
)ccH I
{dd 	
varee 
returnMessageee 
=ee 
stringee  &
.ee& '
Emptyee' ,
;ee, -
vargg 
messagegg 
=gg 
	exceptiongg #
.gg# $
Messagegg$ +
;gg+ ,
ifii 
(ii 
messageii 
.ii 
Containsii  
(ii  !
$strii! F
)iiF G
)iiG H
messagejj 
=jj 
	exceptionjj #
.jj# $
InnerExceptionjj$ 2
.jj2 3
Messagejj3 :
;jj: ;
ifll 
(ll 
messagell 
.ll 
Containsll  
(ll  !
$strll! F
)llF G
)llG H
messagemm 
=mm 
	exceptionmm #
.mm# $
InnerExceptionmm$ 2
.mm2 3
InnerExceptionmm3 A
.mmA B
MessagemmB I
;mmI J
ifoo 
(oo 
messageoo 
.oo 
Containsoo  
(oo  !
$stroo! F
)ooF G
)ooG H
messagepp 
=pp 
	exceptionpp #
.pp# $
InnerExceptionpp$ 2
.pp2 3
InnerExceptionpp3 A
.ppA B
InnerExceptionppB P
.ppP Q
MessageppQ X
;ppX Y
returnMessagerr 
=rr 
newrr 
ExceptionOperationrr  2
(rr2 3
	exceptionrr3 <
)rr< =
.rr= >
GetReturnMessagerr> N
(rrN O
refrrO R
messagerrS Z
)rrZ [
;rr[ \
vartt $
localizatedReturnMessagett (
=tt) * 
_localizationServicett+ ?
.tt? @
GetValuett@ H
(ttH I
returnMessagettI V
)ttV W
;ttW X
returnuu 
stringuu 
.uu 
IsNullOrEmptyuu '
(uu' (
messageuu( /
)uu/ 0
?uu1 2
$"uu3 5
{uu5 6$
localizatedReturnMessageuu6 N
}uuN O
"uuO P
:uuQ R
$"uuS U
{uuU V$
localizatedReturnMessageuuV n
}uun o
 : uuo r
{uur s!
_localizationService	uus á
.
uuá à
GetValue
uuà ê
(
uuê ë
message
uuë ò
)
uuò ô
}
uuô ö
"
uuö õ
;
uuõ ú
}vv 	
}ww 
}xx “
fC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Contracts\ErrorResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Contracts& /
{ 
public 

class 
ErrorResponse 
{ 
public 
ErrorResponse 
( 
	Exception &
	exception' 0
)0 1
{ 	
ExceptionType		 
=		 
	exception		 %
.		% &
GetType		& -
(		- .
)		. /
.		/ 0
ToString		0 8
(		8 9
)		9 :
;		: ;
}

 	
public 
ErrorResponse 
( 
	Exception &
	exception' 0
,0 1
string2 8
errorDetails9 E
)E F
{ 	
ExceptionType 
= 
	exception %
.% &
GetType& -
(- .
). /
./ 0
ToString0 8
(8 9
)9 :
;: ;
ErrorDetails 
= 
errorDetails '
;' (
} 	
public 
ErrorResponse 
( 
	Exception &
	exception' 0
,0 1
string2 8
errorDetails9 E
,E F
stringG M

stackTraceN X
)X Y
{ 	
ExceptionType 
= 
	exception %
.% &
GetType& -
(- .
). /
./ 0
ToString0 8
(8 9
)9 :
;: ;
ErrorDetails 
= 
errorDetails '
;' (

StackTrace 
= 

stackTrace #
;# $
} 	
public 
string 
ExceptionType #
{$ %
get& )
;) *
}+ ,
public 
string 
ErrorDetails "
{# $
get% (
;( )
}* +
public 
string 

StackTrace  
{! "
get# &
;& '
}( )
} 
} ‰
eC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Contracts\IApiResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Contracts& /
{ 
public 

	interface 
IApiResponse !
{ 
} 
} ñ(
iC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Controllers\BaseController.cs
	namespace

 	
CustomFramework


 
.

 
WebApiUtils

 %
.

% &
Controllers

& 1
{ 
public 

abstract 
class 
BaseController (
<( )
TEntity) 0
,0 1
TCreateRequest2 @
,@ A
	TResponseB K
,K L
TManagerM U
,U V
TKeyW [
>[ \
:] ^

Controller_ i
where 
TEntity 
: 
	BaseModel !
<! "
TKey" &
>& '
where 
TManager 
: 
IBusinessManager )
<) *
TEntity* 1
,1 2
TCreateRequest3 A
,A B
TKeyC G
>G H
{ 
	protected 
readonly 
TManager #
Manager$ +
;+ ,
	protected 
readonly  
ILocalizationService /
LocalizationService0 C
;C D
	protected 
readonly 
ILogger "
<" #

Controller# -
>- .
Logger/ 5
;5 6
	protected 
readonly 
IMapper "
Mapper# )
;) *
	protected 
BaseController  
(  !
TManager! )
manager* 1
,1 2 
ILocalizationService3 G
localizationServiceH [
,[ \
ILogger] d
<d e

Controllere o
>o p
loggerq w
,w x
IMapper	y Ä
mapper
Å á
)
á à
{ 	
Manager 
= 
manager 
; 
LocalizationService 
=  !
localizationService" 5
;5 6
Logger 
= 
logger 
; 
Mapper 
= 
mapper 
; 
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :
TCreateRequest; I
requestJ Q
)Q R
{   	
var!! 
result!! 
=!! 
await!! 
Manager!! &
.!!& '
CreateAsync!!' 2
(!!2 3
request!!3 :
)!!: ;
;!!; <
return"" 
Ok"" 
("" 
new"" 
ApiResponse"" %
(""% &
LocalizationService""& 9
,""9 :
Logger""; A
)""A B
.""B C
Ok""C E
(""E F
Mapper""F L
.""L M
Map""M P
<""P Q
TEntity""Q X
,""X Y
	TResponse""Z c
>""c d
(""d e
result""e k
)""k l
)""l m
)""m n
;""n o
}## 	
[%% 	
Route%%	 
(%% 
$str%%  
)%%  !
]%%! "
[&& 	

HttpDelete&&	 
]&& 
public'' 
async'' 
Task'' 
<'' 
IActionResult'' '
>''' (
Delete'') /
(''/ 0
TKey''0 4
id''5 7
)''7 8
{(( 	
await)) 
Manager)) 
.)) 
DeleteAsync)) %
())% &
id))& (
)))( )
;))) *
return** 
Ok** 
(** 
new** 
ApiResponse** %
(**% &
LocalizationService**& 9
,**9 :
Logger**; A
)**A B
.**B C
Ok**C E
(**E F
true**F J
)**J K
)**K L
;**L M
}++ 	
[-- 	
Route--	 
(-- 
$str--  
)--  !
]--! "
[.. 	
HttpGet..	 
].. 
public// 
async// 
Task// 
<// 
IActionResult// '
>//' (
GetById//) 0
(//0 1
TKey//1 5
id//6 8
)//8 9
{00 	
var11 
result11 
=11 
await11 
Manager11 &
.11& '
GetByIdAsync11' 3
(113 4
id114 6
)116 7
;117 8
return22 
Ok22 
(22 
new22 
ApiResponse22 %
(22% &
LocalizationService22& 9
,229 :
Logger22; A
)22A B
.22B C
Ok22C E
(22E F
Mapper22F L
.22L M
Map22M P
<22P Q
TEntity22Q X
,22X Y
	TResponse22Z c
>22c d
(22d e
result22e k
)22k l
)22l m
)22m n
;22n o
}33 	
}44 
}55 ö
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Controllers\BaseControllerWithUpdate.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Controllers& 1
{ 
public 

abstract 
class $
BaseControllerWithUpdate 2
<2 3
TEntity3 :
,: ;
TCreateRequest< J
,J K
TUpdateRequestL Z
,Z [
	TResponse\ e
,e f
TManagerg o
,o p
TKeyq u
>u v
: 	
BaseController
 
< 
TEntity  
,  !
TCreateRequest" 0
,0 1
	TResponse2 ;
,; <
TManager= E
,E F
TKeyG K
>K L
where 
TEntity 
: 
	BaseModel !
<! "
TKey" &
>& '
where 
TManager 
: 
IBusinessManager )
<) *
TEntity* 1
,1 2
TCreateRequest3 A
,A B
TKeyC G
>G H
,H I"
IBusinessManagerUpdateJ `
<` a
TEntitya h
,h i
TUpdateRequestj x
,x y
TKeyz ~
>~ 
{ 
	protected $
BaseControllerWithUpdate *
(* +
TManager+ 3
manager4 ;
,; < 
ILocalizationService= Q
localizationServiceR e
,e f
ILoggerg n
<n o

Controllero y
>y z
logger	{ Å
,
Å Ç
IMapper
É ä
mapper
ã ë
)
ë í
: 	
base
 
( 
manager 
, 
localizationService +
,+ ,
logger- 3
,3 4
mapper5 ;
); <
{ 	
} 	
[ 	
Route	 
( 
$str  
)  !
]! "
[ 	
HttpPut	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
Update) /
(/ 0
TKey0 4
id5 7
,7 8
[9 :
FromBody: B
]B C
TUpdateRequestD R
requestS Z
)Z [
{ 	
var 
result 
= 
await 
Manager &
.& '
UpdateAsync' 2
(2 3
id3 5
,5 6
request7 >
)> ?
;? @
return 
Ok 
( 
new 
ApiResponse %
(% &
LocalizationService& 9
,9 :
Logger; A
)A B
.B C
OkC E
(E F
MapperF L
.L M
MapM P
<P Q
TEntityQ X
,X Y
	TResponseZ c
>c d
(d e
resulte k
)k l
)l m
)m n
;n o
} 	
}   
}!! ⁄
gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Enums\BusinessUtilMethod.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Enums& +
{ 
public 

enum 
BusinessUtilMethod "
{ $
UniqueGenericListChecker  
,  !,
 CheckDuplicatationForUniqueValue (
,( )
CheckRecordIsExist 
, 
CheckUniqueValue 
, 
CheckNothing		 
,		 
}

 
} »
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Extensions\ResponseWrapperExtensions.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &

Extensions& 0
{ 
public 

static 
class %
ResponseWrapperExtensions 1
{ 
public 
static 
IApplicationBuilder )&
UseErrorWrappingMiddleware* D
(D E
thisE I
IApplicationBuilderJ ]
builder^ e
)e f
{		 	
return

 
builder

 
.

 
UseMiddleware

 (
<

( )#
ErrorWrappingMiddleware

) @
>

@ A
(

A B
)

B C
;

C D
} 	
} 
} Í
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Extensions\SwaggerSecurityRequirementsDocumentFilter.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &

Extensions& 0
{ 
internal 
class 5
)SwaggerSecurityRequirementsDocumentFilter <
:= >
IDocumentFilter? N
{ 
public		 
void		 
Apply		 
(		 
SwaggerDocument		 )

swaggerDoc		* 4
,		4 5!
DocumentFilterContext		6 K
context		L S
)		S T
{

 	

swaggerDoc 
. 
Security 
=  !
new" %
List& *
<* +
IDictionary+ 6
<6 7
string7 =
,= >
IEnumerable? J
<J K
stringK Q
>Q R
>R S
>S T
{ 
new 

Dictionary 
< 
string %
,% &
IEnumerable' 2
<2 3
string3 9
>9 :
>: ;
(; <
)< =
{ 
{ 
$str 
, 
new  #
string$ *
[* +
]+ ,
{, -
}. /
}0 1
,1 2
{ 
$str 
, 
new "
string# )
[) *
]* +
{+ ,
}- .
}/ 0
,0 1
} 
} 
; 
} 	
} 
} Ä
qC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Extensions\SwaggerServiceExtension.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &

Extensions& 0
{ 
public 

static 
class #
SwaggerServiceExtension /
{ 
public		 
static		 
IServiceCollection		 (#
AddSwaggerDocumentation		) @
(		@ A
this		A E
IServiceCollection		F X
services		Y a
)		a b
{

 	
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
c 
. 

SwaggerDoc 
( 
$str #
,# $
new% (
Info) -
{. /
Title0 5
=6 7
$str8 G
,G H
VersionI P
=Q R
$strS Y
}Z [
)[ \
;\ ]
c 
. !
AddSecurityDefinition '
(' (
$str( 0
,0 1
new2 5
ApiKeyScheme6 B
{ 
Description 
=  !
$str	" Ä
,
Ä Å
Name 
= 
$str *
,* +
In 
= 
$str !
,! "
Type 
= 
$str #
} 
) 
; 
c 
. 
DocumentFilter  
<  !5
)SwaggerSecurityRequirementsDocumentFilter! J
>J K
(K L
)L M
;M N
} 
) 
; 
return 
services 
; 
} 	
public 
static 
IApplicationBuilder )#
UseSwaggerDocumentation* A
(A B
thisB F
IApplicationBuilderG Z
app[ ^
)^ _
{ 	
app 
. 

UseSwagger 
( 
) 
; 
app   
.   
UseSwaggerUI   
(   
c   
=>   !
{!! 
const"" 
string"" 
url""  
=""! "
$str""# ?
;""? @
c## 
.## 
SwaggerEndpoint## !
(##! "
url##" %
,##% &
$str##' ;
)##; <
;##< =
c$$ 
.$$ 
DocExpansion$$ 
($$ 
DocExpansion$$ +
.$$+ ,
None$$, 0
)$$0 1
;$$1 2
}%% 
)%% 
;%% 
return'' 
app'' 
;'' 
}(( 	
})) 
}** ˇ
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Extensions\WebApiUtilServiceExtensions.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &

Extensions& 0
{ 
public 

static 
class '
WebApiUtilServiceExtensions 3
{ 
public 
static 
IServiceCollection (!
AddWebApiUtilServices) >
(> ?
this? C
IServiceCollectionD V
servicesW _
)_ `
{		 	
services

 
.

 
AddSingleton

 !
<

! " 
IHttpContextAccessor

" 6
,

6 7
HttpContextAccessor

8 K
>

K L
(

L M
)

M N
;

N O
services 
. 
AddCors 
( 
) 
; 
return 
services 
; 
} 	
} 
} ≤
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Middlewares\ErrorWrappingMiddleware.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Middlewares& 1
{ 
public 

class #
ErrorWrappingMiddleware (
{ 
private 
readonly 
RequestDelegate (
_next) .
;. /
private 
readonly 
ILogger  
<  !#
ErrorWrappingMiddleware! 8
>8 9
_logger: A
;A B
private 
readonly  
ILocalizationService - 
_localizationService. B
;B C
public #
ErrorWrappingMiddleware &
(& '
RequestDelegate' 6
next7 ;
,; <
ILogger= D
<D E#
ErrorWrappingMiddlewareE \
>\ ]
logger^ d
,d e 
ILocalizationServicef z 
localizationService	{ é
)
é è
{ 	
_next 
= 
next 
?? 
throw !
new" %!
ArgumentNullException& ;
(; <
nameof< B
(B C
nextC G
)G H
)H I
;I J 
_localizationService  
=! "
localizationService# 6
;6 7
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
)4 5
{ 	
try 
{ 
await   
_next   
.   
Invoke   "
(  " #
context  # *
)  * +
;  + ,
}!! 
catch"" 
("" 
	Exception"" 
ex"" 
)""  
{## 
if$$ 
($$ 
context$$ 
.$$ 
Response$$ $
.$$$ %

HasStarted$$% /
)$$/ 0
{%% 
_logger&& 
.&& 

LogWarning&& &
(&&& '
$str	&&' Ä
)
&&Ä Å
;
&&Å Ç
throw'' 
;'' 
}(( 
context** 
.** 
Response**  
.**  !

StatusCode**! +
=**, -
(**. /
int**/ 2
)**2 3
ex**3 5
.**5 6!
ExceptionToStatusCode**6 K
(**K L
)**L M
;**M N
context++ 
.++ 
Response++  
.++  !
ContentType++! ,
=++- .
$str++/ A
;++A B
var-- 
apiResponse-- 
=--  !
new--" %
ApiResponse--& 1
(--1 2 
_localizationService--2 F
,--F G
_logger--H O
)--O P
.--P Q
Error--Q V
(--V W
(--W X
HttpStatusCode--X f
)--f g
context--g n
.--n o
Response--o w
.--w x

StatusCode	--x Ç
,
--Ç É
ex
--Ñ Ü
)
--Ü á
;
--á à
var// 
json// 
=// 
JsonConvert// &
.//& '
SerializeObject//' 6
(//6 7
apiResponse//7 B
,//B C
new//D G"
JsonSerializerSettings//H ^
{00 
ContractResolver11 $
=11% &
new11' *2
&CamelCasePropertyNamesContractResolver11+ Q
(11Q R
)11R S
}22 
)22 
;22 
await33 
context33 
.33 
Response33 &
.33& '

WriteAsync33' 1
(331 2
json332 6
)336 7
;337 8
}44 
}55 	
}66 
}77 ˘
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Resources\ILocalizationService.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
	Resources& /
{ 
public 

	interface  
ILocalizationService )
{ 
LocalizedString 
GetValue  
(  !
string! '
key( +
)+ ,
;, -
} 
}		 »O
aC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\BusinessUtil.cs
	namespace

 	
CustomFramework


 
.

 
WebApiUtils

 %
.

% &
Utils

& +
{ 
public 

static 
class 
BusinessUtil $
{ 
public 
static 
void 
Execute "
<" #
TEntity# *
>* +
(+ ,
BusinessUtilMethod, >
businessUtilMethod? Q
,Q R
TEntityS Z
result[ a
,a b
stringc i
additionnalInfoj y
)y z
{ 	
switch 
( 
businessUtilMethod &
)& '
{ 
case 
BusinessUtilMethod '
.' ($
UniqueGenericListChecker( @
:@ A
result 
. $
UniqueGenericListChecker 3
(3 4
additionnalInfo4 C
)C D
;D E
break 
; 
case 
BusinessUtilMethod '
.' (,
 CheckDuplicatationForUniqueValue( H
:H I
result 
. ,
 CheckDuplicatationForUniqueValue ;
(; <
additionnalInfo< K
)K L
;L M
break 
; 
case 
BusinessUtilMethod '
.' (
CheckRecordIsExist( :
:: ;
result 
. 
CheckRecordIsExist -
(- .
additionnalInfo. =
)= >
;> ?
break 
; 
case 
BusinessUtilMethod '
.' (
CheckUniqueValue( 8
:8 9
result 
. 
CheckUniqueValue +
(+ ,
additionnalInfo, ;
); <
;< =
break 
; 
case 
BusinessUtilMethod '
.' (
CheckNothing( 4
:4 5
break 
; 
default   
:   
throw!! 
new!! '
ArgumentOutOfRangeException!! 9
(!!9 :
$str!!: X
,!!X Y
businessUtilMethod!!Z l
.!!l m
ToString!!m u
(!!u v
)!!v w
)!!w x
;!!x y
}"" 
}## 	
public%% 
static%% 
void%% $
UniqueGenericListChecker%% 3
<%%3 4
T%%4 5
>%%5 6
(%%6 7
this%%7 ;
T%%< =
result%%> D
,%%D E
string%%F L
additionalInfo%%M [
)%%[ \
{&& 	
result'' 
.'' ,
 CheckDuplicatationForUniqueValue'' 3
(''3 4
additionalInfo''4 B
.''B C
RemoveManagerString''C V
(''V W
)''W X
)''X Y
;''Y Z
result(( 
.(( 
CheckRecordIsExist(( %
(((% &
additionalInfo((& 4
.((4 5
RemoveManagerString((5 H
(((H I
)((I J
)((J K
;((K L
})) 	
public++ 
static++ 
void++ ,
 CheckDuplicatationForUniqueValue++ ;
<++; <
T++< =
>++= >
(++> ?
this++? C
T++D E
result++F L
,++L M
string++N T
additionalInfo++U c
)++c d
{,, 	
if-- 
(-- 
result-- 
.-- 
GetGenericTypeCount-- *
(--* +
)--+ ,
<=--- /
$num--0 1
)--1 2
return--3 9
;--9 :
throw.. 
new.. "
DuplicateNameException.. ,
(.., -
additionalInfo..- ;
...; <
RemoveManagerString..< O
(..O P
)..P Q
)..Q R
;..R S
}// 	
public11 
static11 
void11 
CheckRecordIsExist11 -
<11- .
T11. /
>11/ 0
(110 1
this111 5
T116 7
result118 >
,11> ?
string11@ F
additionalInfo11G U
)11U V
{22 	
if33 
(33 
!33 
result33 
.33 $
GenericTypeIsNullOrEmpty33 0
(330 1
)331 2
)332 3
return334 :
;33: ;
throw44 
new44  
KeyNotFoundException44 *
(44* +
additionalInfo44+ 9
.449 :
RemoveManagerString44: M
(44M N
)44N O
)44O P
;44P Q
}55 	
public77 
static77 
void77 
CheckUniqueValue77 +
<77+ ,
TEntity77, 3
>773 4
(774 5
this775 9
TEntity77: A
result77B H
,77H I
string77J P
additionalInfo77Q _
)77_ `
{88 	
if99 
(99 
!99 
result99 
.99 $
GenericTypeIsNullOrEmpty99 0
(990 1
)991 2
)992 3
throw994 9
new99: ="
DuplicateNameException99> T
(99T U
additionalInfo99U c
.99c d
RemoveManagerString99d w
(99w x
)99x y
)99y z
;99z {
}:: 	
public<< 
static<< 
void<< %
CheckUniqueValueForUpdate<< 4
<<<4 5
TEntity<<5 <
,<<< =
TKey<<> B
><<B C
(<<C D
this<<D H
TEntity<<I P
result<<Q W
,<<W X
TKey<<Y ]
id<<^ `
,<<` a
string<<b h
additionalInfo<<i w
)<<w x
where<<y ~
TEntity	<< Ü
:
<<á à
	BaseModel
<<â í
<
<<í ì
TKey
<<ì ó
>
<<ó ò
{== 	
if>> 
(>> 
result>> 
.>> $
GenericTypeIsNullOrEmpty>> /
(>>/ 0
)>>0 1
)>>1 2
return>>3 9
;>>9 :
if?? 
(?? 
!?? 
result?? 
.?? 
Id?? 
.?? 
Equals?? !
(??! "
id??" $
)??$ %
)??% &
throw@@ 
new@@ "
DuplicateNameException@@ 0
(@@0 1
additionalInfo@@1 ?
.@@? @
RemoveManagerString@@@ S
(@@S T
)@@T U
)@@U V
;@@V W
}AA 	
publicCC 
staticCC 
voidCC %
CheckUniqueValueForUpdateCC 4
<CC4 5
TEntityCC5 <
,CC< =
TKeyCC> B
>CCB C
(CCC D
thisCCD H
IListCCI N
<CCN O
TEntityCCO V
>CCV W
resultCCX ^
,CC^ _
TKeyCC` d
idCCe g
,CCg h
stringCCi o
additionalInfoCCp ~
)CC~ 
where
CCÄ Ö
TEntity
CCÜ ç
:
CCé è
	BaseModel
CCê ô
<
CCô ö
TKey
CCö û
>
CCû ü
{DD 	
ifEE 
(EE 
resultEE 
.EE $
GenericTypeIsNullOrEmptyEE /
(EE/ 0
)EE0 1
)EE1 2
returnEE3 9
;EE9 :
ifFF 
(FF 
!FF 
resultFF 
.FF 
AnyFF 
(FF 
pFF 
=>FF  
pFF! "
.FF" #
IdFF# %
.FF% &
EqualsFF& ,
(FF, -
idFF- /
)FF/ 0
)FF0 1
)FF1 2
throwGG 
newGG "
DuplicateNameExceptionGG 0
(GG0 1
additionalInfoGG1 ?
.GG? @
RemoveManagerStringGG@ S
(GGS T
)GGT U
)GGU V
;GGV W
}HH 	
privateJJ 
staticJJ 
boolJJ $
GenericTypeIsNullOrEmptyJJ 4
<JJ4 5
TJJ5 6
>JJ6 7
(JJ7 8
thisJJ8 <
TJJ= >
valueJJ? D
)JJD E
{KK 	
returnLL 
valueLL 
.LL 
GetGenericTypeCountLL ,
(LL, -
)LL- .
<=LL/ 1
$numLL2 3
;LL3 4
}MM 	
privateOO 
staticOO 
intOO 
GetGenericTypeCountOO .
<OO. /
TOO/ 0
>OO0 1
(OO1 2
thisOO2 6
TOO7 8
valueOO9 >
)OO> ?
{PP 	
ifQQ 
(QQ 
valueQQ 
==QQ 
nullQQ 
)QQ 
returnQQ %
$numQQ& '
;QQ' (
varRR 
piRR 
=RR 
valueRR 
.RR 
GetTypeRR "
(RR" #
)RR# $
.RR$ %
GetPropertyRR% 0
(RR0 1
$strRR1 8
)RR8 9
;RR9 :
ifSS 
(SS 
piSS 
!=SS 
nullSS 
)SS 
{TT 
varUU 
countUU 
=UU 
ConvertUU #
.UU# $
ToInt32UU$ +
(UU+ ,
piUU, .
.UU. /
GetValueUU/ 7
(UU7 8
valueUU8 =
)UU= >
)UU> ?
;UU? @
returnVV 
countVV 
;VV 
}WW 
elseXX 
{YY 
returnZZ 
$numZZ 
;ZZ 
}[[ 
}\\ 	
private^^ 
static^^ 
string^^ 
RemoveManagerString^^ 1
(^^1 2
this^^2 6
string^^7 =
value^^> C
)^^C D
{__ 	
const`` 
string`` 
removalString`` &
=``' (
$str``) 2
;``2 3
returnaa 
valueaa 
.aa 
Containsaa !
(aa! "
removalStringaa" /
)aa/ 0
?aa1 2
valueaa3 8
.aa8 9
Replaceaa9 @
(aa@ A
removalStringaaA N
,aaN O
stringaaP V
.aaV W
EmptyaaW \
)aa\ ]
:aa^ _
valueaa` e
;aae f
}bb 	
}cc 
}dd ﬂ
aC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\ConfigHelper.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
{ 
public 

static 
class 
ConfigHelper $
{ 
private 
static 
IConfigurationRoot )
GetConfiguration* :
(: ;
); <
{		 	
var

 
builder

 
=

 
new

  
ConfigurationBuilder

 2
(

2 3
)

3 4
. 
SetBasePath 
( 
	Directory &
.& '
GetCurrentDirectory' :
(: ;
); <
)< =
. 
AddJsonFile 
( 
$str /
)/ 0
;0 1
return 
builder 
. 
Build  
(  !
)! "
;" #
} 	
public 
static 
string !
GetConfigurationValue 2
(2 3
string3 9
key: =
)= >
{ 	
return 
GetConfiguration #
(# $
)$ %
[% &
key& )
]) *
;* +
} 	
public 
static 
IConfiguration $

GetSection% /
(/ 0
string0 6
key7 :
): ;
{ 	
return 
GetConfiguration #
(# $
)$ %
.% &

GetSection& 0
(0 1
key1 4
)4 5
;5 6
} 	
} 
} „
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\ArgumentError.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

class 
ArgumentError 
:  
IExceptionStrategy! 3
{ 
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{		 	
return

 #
DefaultResponseMessages

 *
.

* +"
ArgumentExceptionError

+ A
;

A B
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
HttpStatusCode !
.! "

BadRequest" ,
;, -
} 	
} 
} Œ
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\AuthenticationError.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

class 
AuthenticationError $
:% &
IExceptionStrategy' 9
{ 
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{		 	
message

 
=

 
string

 
.

 
Empty

 "
;

" #
return #
DefaultResponseMessages *
.* +

LoginError+ 5
;5 6
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
HttpStatusCode !
.! "
Unauthorized" .
;. /
} 	
} 
} Â
lC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\DefaultError.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

class 
DefaultError 
: 
IExceptionStrategy  2
{ 
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{		 	
return

 #
DefaultResponseMessages

 *
.

* +
AnErrorHasOccured

+ <
;

< =
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
HttpStatusCode !
.! "
InternalServerError" 5
;5 6
} 	
} 
} Ë
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\DuplicateNameError.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

class 
DuplicateNameError #
:$ %
IExceptionStrategy& 8
{ 
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{		 	
return

 #
DefaultResponseMessages

 *
.

* +
RecordExistsError

+ <
;

< =
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
HttpStatusCode !
.! "

BadRequest" ,
;, -
} 	
} 
} £
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\ExceptionOperation.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{		 
public

 

class

 
ExceptionOperation

 #
:

$ %
IExceptionStrategy

& 8
{ 
private 
readonly 
	Exception "

_exception# -
;- .
private 
IExceptionStrategy "
_exceptionStrategy# 5
;5 6
public 
ExceptionOperation !
(! "
	Exception" +
	exception, 5
)5 6
{ 	

_exception 
= 
	exception "
;" ##
SelectExceptionStrategy #
(# $
)$ %
;% &
} 	
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{ 	
return 
_exceptionStrategy %
.% &
GetReturnMessage& 6
(6 7
ref7 :
message; B
)B C
;C D
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
_exceptionStrategy %
.% &
GetHttpStatusCode& 7
(7 8
)8 9
;9 :
} 	
private 
void #
SelectExceptionStrategy ,
(, -
)- .
{   	
switch!! 
(!! 

_exception!! 
)!! 
{"" 
case## "
DuplicateNameException## +
_##, -
:##- .
_exceptionStrategy$$ &
=$$' (
new$$) ,
DuplicateNameError$$- ?
($$? @
)$$@ A
;$$A B
break%% 
;%% 
case&&  
KeyNotFoundException&& )
_&&* +
:&&+ ,
_exceptionStrategy'' &
=''' (
new'') ,
KeyNotFoundError''- =
(''= >
)''> ?
;''? @
break(( 
;(( 
case)) 
ArgumentException)) &
_))' (
:))( )
_exceptionStrategy** &
=**' (
new**) ,
ArgumentError**- :
(**: ;
)**; <
;**< =
break++ 
;++ 
case,, #
AuthenticationException,, ,
_,,- .
:,,. /
_exceptionStrategy-- &
=--' (
new--) ,
AuthenticationError--- @
(--@ A
)--A B
;--B C
break.. 
;.. 
case// '
UnauthorizedAccessException// 0
_//1 2
://2 3
_exceptionStrategy00 &
=00' (
new00) ,#
UnauthorizedAccessError00- D
(00D E
)00E F
;00F G
break11 
;11 
default22 
:22 
_exceptionStrategy33 &
=33' (
new33) ,
DefaultError33- 9
(339 :
)33: ;
;33; <
break44 
;44 
}55 
}66 	
}88 
}99 ˙
~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\ExceptionToStatusCodeConverter.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

static 
class *
ExceptionToStatusCodeConverter 6
{		 
public

 
static

 
HttpStatusCode

 $!
ExceptionToStatusCode

% :
(

: ;
this

; ?
	Exception

@ I
	exception

J S
)

S T
{ 	
return 
new 
ExceptionOperation )
() *
	exception* 3
)3 4
.4 5
GetHttpStatusCode5 F
(F G
)G H
;H I
} 	
} 
} õ
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\IExceptionStrategy.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

	interface 
IExceptionStrategy '
{ 
string 
GetReturnMessage 
(  
ref  #
string$ *
message+ 2
)2 3
;3 4
HttpStatusCode		 
GetHttpStatusCode		 (
(		( )
)		) *
;		* +
}

 
} ﬁ
pC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\KeyNotFoundError.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

class 
KeyNotFoundError !
:" #
IExceptionStrategy$ 6
{ 
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{		 	
return

 #
DefaultResponseMessages

 *
.

* +
NotFoundError

+ 8
;

8 9
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
HttpStatusCode !
.! "
NotFound" *
;* +
} 	
} 
} é
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\ModelStateToString.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Utils		& +
.		+ ,

Exceptions		, 6
{

 
public 

static 
class '
ModelStateToStringConverter 3
{ 
public 
static 
string 
ModelStateToString /
(/ 0
this0 4 
ModelStateDictionary5 I

modelStateJ T
,T U 
ILocalizationServiceV j
localizationServicek ~
)~ 
{ 	
if 
( 

modelState 
. 
IsValid "
)" #
{ 
throw 
new 
ArgumentException +
(+ ,#
DefaultResponseMessages, C
.C D 
ModelStateValidErrorD X
,X Y
nameofZ `
(` a

modelStatea k
)k l
)l m
;m n
} 
var 
modelStateStrings !
=" #

modelState$ .
.. /

SelectMany/ 9
(9 :
x: ;
=>< >
x? @
.@ A
ValueA F
.F G
ErrorsG M
)M N
. 
Select 
( 
x 
=> 
x 
. 
ErrorMessage +
)+ ,
., -
ToArray- 4
(4 5
)5 6
;6 7
var  
newModelStateStrings $
=% &
new' *
List+ /
</ 0
string0 6
>6 7
(7 8
)8 9
;9 :
foreach 
( 
var 
modelStateString )
in* ,
modelStateStrings- >
)> ?
{ 
var 
localisedModelState '
=( )
new* -
StringBuilder. ;
(; <
)< =
;= >
var $
localisedModelStateArray ,
=- .
modelStateString/ ?
.? @
Split@ E
(E F
$charF I
)I J
;J K
foreach 
( 
var 
item !
in" $$
localisedModelStateArray% =
)= >
{ 
localisedModelState '
.' (
Append( .
(. /
$"/ 1
{1 2
localizationService2 E
.E F
GetValueF N
(N O
itemO S
.S T
TrimT X
(X Y
)Y Z
)Z [
}[ \
 : \ _
"_ `
)` a
;a b
}    
newModelStateStrings"" $
.""$ %
Add""% (
(""( )
localisedModelState"") <
.""< =
ToString""= E
(""E F
)""F G
.""G H
Remove""H N
(""N O
localisedModelState""O b
.""b c
Length""c i
-""j k
$num""l m
,""m n
$num""o p
)""p q
)""q r
;""r s
}## 
return%% 
string%% 
.%% 
Join%% 
(%% 
$str%% "
,%%" # 
newModelStateStrings%%$ 8
.%%8 9
ToArray%%9 @
(%%@ A
)%%A B
)%%B C
;%%C D
}&& 	
}(( 
})) ‡
wC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils\Utils\Exceptions\UnauthorizedAccessError.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Utils& +
.+ ,

Exceptions, 6
{ 
public 

class #
UnauthorizedAccessError (
:) *
IExceptionStrategy+ =
{ 
public 
string 
GetReturnMessage &
(& '
ref' *
string+ 1
message2 9
)9 :
{		 	
message

 
=

 
string

 
.

 
Empty

 "
;

" #
return #
DefaultResponseMessages *
.* +#
UnauthorizedAccessError+ B
;B C
} 	
public 
HttpStatusCode 
GetHttpStatusCode /
(/ 0
)0 1
{ 	
return 
HttpStatusCode !
.! "
	Forbidden" +
;+ ,
} 	
} 
} 