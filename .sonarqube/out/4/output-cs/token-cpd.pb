è#
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\AutoMapper\AuthorizationMappingProfile.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

AutoMapper4 >
{ 
public 

class '
AuthorizationMappingProfile ,
:- .
Profile/ 6
{		 
public

 
void

 
Map

 
(

 
)

 
{ 	
	CreateMap 
< 
Claim 
, 
ClaimResponse *
>* +
(+ ,
), -
;- .
	CreateMap 
< 
ClaimRequest "
," #
Claim$ )
>) *
(* +
)+ ,
;, -
	CreateMap 
< 
ClientApplication '
,' (%
ClientApplicationResponse) B
>B C
(C D
)D E
;E F
	CreateMap 
< $
ClientApplicationRequest .
,. /
ClientApplication0 A
>A B
(B C
)C D
;D E
	CreateMap 
< *
ClientApplicationUpdateRequest 4
,4 5
ClientApplication6 G
>G H
(H I
)I J
;J K
	CreateMap 
< (
ClientApplicationUtilRequest 2
,2 3
ClientApplication4 E
>E F
(F G
)G H
;H I
	CreateMap 
< 
Role 
, 
RoleResponse (
>( )
() *
)* +
;+ ,
	CreateMap 
< 
RoleRequest !
,! "
Role# '
>' (
(( )
)) *
;* +
	CreateMap 
< 
	RoleClaim 
,  
RoleClaimResponse! 2
>2 3
(3 4
)4 5
;5 6
	CreateMap 
< 
RoleClaimRequest &
,& '
	RoleClaim( 1
>1 2
(2 3
)3 4
;4 5
	CreateMap 
< "
RoleEntityClaimRequest ,
,, -
RoleEntityClaim. =
>= >
(> ?
)? @
;@ A
	CreateMap 
< 
RoleEntityClaim %
,% &#
RoleEntityClaimResponse' >
>> ?
(? @
)@ A
;A B
	CreateMap 
< 
EntityClaimRequest (
,( )
RoleEntityClaim* 9
>9 :
(: ;
); <
;< =
	CreateMap 
< 
	UserClaim 
,  
UserClaimResponse! 2
>2 3
(3 4
)4 5
;5 6
	CreateMap   
<   
UserClaimRequest   &
,  & '
	UserClaim  ( 1
>  1 2
(  2 3
)  3 4
;  4 5
	CreateMap"" 
<"" 
UserEntityClaim"" %
,""% &#
UserEntityClaimResponse""' >
>""> ?
(""? @
)""@ A
;""A B
	CreateMap## 
<## "
UserEntityClaimRequest## ,
,##, -
UserEntityClaim##. =
>##= >
(##> ?
)##? @
;##@ A
	CreateMap$$ 
<$$ 
EntityClaimRequest$$ (
,$$( )
UserEntityClaim$$* 9
>$$9 :
($$: ;
)$$; <
;$$< =
	CreateMap&& 
<&& 
UserRequest&& !
,&&! "
User&&# '
>&&' (
(&&( )
)&&) *
;&&* +
	CreateMap'' 
<'' 
User'' 
,'' 
UserResponse'' (
>''( )
('') *
)''* +
;''+ ,
	CreateMap)) 
<)) 
UserRole)) 
,)) 
UserRoleResponse))  0
>))0 1
())1 2
)))2 3
;))3 4
	CreateMap** 
<** 
UserRoleRequest** %
,**% &
UserRole**' /
>**/ 0
(**0 1
)**1 2
;**2 3
	CreateMap,, 
<,, 
UserUtilRequest,, %
,,,% &
UserUtil,,' /
>,,/ 0
(,,0 1
),,1 2
;,,2 3
}.. 	
}// 
}00 ∂
áC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\BaseBusinessManagerWithApiRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
{ 
public		 

class		 -
!BaseBusinessManagerWithApiRequest		 2
<		2 3
TApiRequest		3 >
>		> ?
:		@ A
BaseBusinessManager		B U
where

 
TApiRequest

 
:

 
IApiRequest

  +
{ 
	protected 
readonly 
IApiRequest &
ApiRequestAccessor' 9
;9 :
public -
!BaseBusinessManagerWithApiRequest 0
(0 1
ILogger1 8
<8 9
BaseBusinessManager9 L
>L M
loggerN T
,T U
IMapperV ]
mapper^ d
,d e
IApiRequestAccessorf y
apiRequestAccessor	z å
)
å ç
: 
base 
( 
logger 
, 
mapper !
)! "
{ 	
ApiRequestAccessor 
=  
apiRequestAccessor! 3
.3 4
GetApiRequest4 A
<A B
TApiRequestB M
>M N
(N O
)O P
;P Q
} 	
} 
} ˛	
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{		 
public

 

	interface

 
IClaimManager

 "
:

# $
IBusinessManager

% 5
<

5 6
Claim

6 ;
,

; <
ClaimRequest

= I
,

I J
int

K N
>

N O
,$ %"
IBusinessManagerUpdate& <
<< =
Claim= B
,B C
ClaimRequestD P
,P Q
intR U
>U V
{ 
Task 
< 
Claim 
> !
GetByCustomClaimAsync )
() *
string* 0
customClaim1 <
)< =
;= >
Task 
< 
ICustomList 
< 
Claim 
> 
>  
GetAllAsync! ,
(, -
int- 0
	pageIndex1 :
,: ;
int< ?
pageSize@ H
)H I
;I J
} 
} À
âC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IClientApplicationManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public 

	interface %
IClientApplicationManager .
:/ 0
IBusinessManager1 A
<A B
ClientApplicationB S
,S T$
ClientApplicationRequestU m
,m n
into r
>r s
,		0 1"
IBusinessManagerUpdate		2 H
<		H I
ClientApplication		I Z
,		Z [*
ClientApplicationUpdateRequest		\ z
,		z {
int		| 
>			 Ä
{

 
Task 
< 
ClientApplication 
> 0
$UpdateClientApplicationPasswordAsync  D
(D E
intE H
idI K
,K L
stringM S%
clientApplicationPasswordT m
)m n
;n o
Task 
< 
ClientApplication 
> +
GetByClientApplicationCodeAsync  ?
(? @
string@ F
codeG K
)K L
;L M
Task 
< 
ClientApplication 
> 

LoginAsync  *
(* +
string+ 1
code2 6
,6 7
string8 >
password? G
)G H
;H I
} 
} Î
çC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IClientApplicationUtilManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public 

	interface )
IClientApplicationUtilManager 2
:3 4
IBusinessManager5 E
<E F!
ClientApplicationUtilF [
,[ \(
ClientApplicationUtilRequest] y
,y z
int{ ~
>~ 
,		4 5"
IBusinessManagerUpdate		6 L
<		L M!
ClientApplicationUtil		M b
,		b c/
"ClientApplicationUtilUpdateRequest			d Ü
,
		Ü á
int
		à ã
>
		ã å
{

 
Task 
< !
ClientApplicationUtil "
>" #)
GetByClientApplicationIdAsync$ A
(A B
intB E
clientApplicationIdF Y
)Y Z
;Z [
} 
} ã
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IRoleClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{		 
public

 

	interface

 
IRoleClaimManager

 &
:

' (
IBusinessManager

) 9
<

9 :
	RoleClaim

: C
,

C D
RoleClaimRequest

E U
,

U V
int

W Z
>

Z [
{ 
Task 
< 
bool 
> +
RolesAreAuthorizedForClaimAsync 2
(2 3
IList3 8
<8 9
Role9 =
>= >
roles? D
,D E
intF I
claimIdJ Q
)Q R
;R S
Task 
< 
ICustomList 
< 
Claim 
> 
>  "
GetClaimsByRoleIdAsync! 7
(7 8
int8 ;
roleId< B
)B C
;C D
Task 
< 
ICustomList 
< 
Role 
> 
> "
GetRolesByClaimIdAsync  6
(6 7
int7 :
claimId; B
)B C
;C D
} 
} ≤
áC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IRoleEntityClaimManager.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Business		4 <
.		< =
	Contracts		= F
{

 
public 

	interface #
IRoleEntityClaimManager ,
:- .
IBusinessManager/ ?
<? @
RoleEntityClaim@ O
,O P"
RoleEntityClaimRequestQ g
,g h
inti l
>l m
,- ."
IBusinessManagerUpdate/ E
<E F
RoleEntityClaimF U
,U V
EntityClaimRequestW i
,i j
intk n
>n o
{ 
Task 
< 
bool 
> 1
%RolesAreAuthorizedForEntityClaimAsync 8
(8 9
IEnumerable9 D
<D E
RoleE I
>I J
rolesK P
,P Q
stringR X
entityY _
,_ `
Cruda e
crudf j
)j k
;k l
Task 
< 
ICustomList 
< 
RoleEntityClaim (
>( )
>) *
GetAllByEntityAsync+ >
(> ?
string? E
entityF L
)L M
;M N
Task 
< 
ICustomList 
< 
RoleEntityClaim (
>( )
>) *
GetAllByRoleIdAsync+ >
(> ?
int? B
roleIdC I
)I J
;J K
} 
} ä	
|C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IRoleManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public		 

	interface		 
IRoleManager		 !
:		" #
IBusinessManager		$ 4
<		4 5
Role		5 9
,		9 :
RoleRequest		; F
,		F G
int		H K
>		K L
,

$ %"
IBusinessManagerUpdate

& <
<

< =
Role

= A
,

A B
RoleRequest

C N
,

N O
int

P S
>

S T
{ 
Task 
< 
Role 
> 
GetByNameAsync !
(! "
string" (
name) -
)- .
;. /
Task 
< 
ICustomList 
< 
Role 
> 
> 
GetAllAsync  +
(+ ,
), -
;- .
} 
} ÿ

ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IUserClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public		 

	interface		 
IUserClaimManager		 &
:		' (
IBusinessManager		) 9
<		9 :
	UserClaim		: C
,		C D
UserClaimRequest		E U
,		U V
int		W Z
>		Z [
{

 
Task 
< 
bool 
> )
UserIsAuthorizedForClaimAsync 0
(0 1
int1 4
userId5 ;
,; <
int= @
claimIdA H
)H I
;I J
Task 
< 
ICustomList 
< 
Claim 
> 
>  "
GetClaimsByUserIdAsync! 7
(7 8
int8 ;
userId< B
)B C
;C D
Task 
< 
ICustomList 
< 
User 
> 
> "
GetUsersByClaimIdAsync  6
(6 7
int7 :
claimId; B
)B C
;C D
} 
} ˘
áC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IUserEntityClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{		 
public

 

	interface

 #
IUserEntityClaimManager

 ,
:

- .
IBusinessManager

/ ?
<

? @
UserEntityClaim

@ O
,

O P"
UserEntityClaimRequest

Q g
,

g h
int

i l
>

l m
,0 1"
IBusinessManagerUpdate2 H
<H I
UserEntityClaimI X
,X Y
EntityClaimRequestZ l
,l m
intn q
>q r
{ 
Task 
< 
bool 
> /
#UserIsAuthorizedForEntityClaimAsync 6
(6 7
int7 :
userId; A
,A B
stringC I
entityJ P
,P Q
CrudR V
crudW [
)[ \
;\ ]
Task 
< 
ICustomList 
< 
UserEntityClaim (
>( )
>) *
GetAllByEntityAsync+ >
(> ?
string? E
entityF L
)L M
;M N
Task 
< 
ICustomList 
< 
UserEntityClaim (
>( )
>) *
GetAllByUserIdAsync+ >
(> ?
int? B
userIdC I
)I J
;J K
} 
} º
|C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IUserManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public		 

	interface		 
IUserManager		 !
:		" #
IBusinessManager		$ 4
<		4 5
User		5 9
,		9 :
UserRequest		; F
,		F G
int		H K
>		K L
{

 
Task 
< 
User 
> 
UpdateUserNameAsync &
(& '
int' *
id+ -
,- .
string/ 5
userName6 >
)> ?
;? @
Task 
< 
User 
> 
UpdatePasswordAsync &
(& '
int' *
id+ -
,- .
string/ 5
password6 >
)> ?
;? @
Task 
< 
User 
> 
UpdateEmailAsync #
(# $
int$ '
id( *
,* +
string, 2
email3 8
)8 9
;9 :
Task 
< 
User 
> 

LoginAsync 
( 
string $
userName% -
,- .
string/ 5
password6 >
)> ?
;? @
Task 
< 
User 
> 
GetByUserNameAsync %
(% &
string& ,
userName- 5
)5 6
;6 7
Task 
< 
User 
> 
GetByEmailAsync "
(" #
string# )
email* /
)/ 0
;0 1
Task 
< 
ICustomList 
< 
User 
> 
> 
GetAllAsync  +
(+ ,
), -
;- .
} 
} ‹
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IUserRoleManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public		 

	interface		 
IUserRoleManager		 %
:		& '
IBusinessManager		( 8
<		8 9
UserRole		9 A
,		A B
UserRoleRequest		C R
,		R S
int		T W
>		W X
{

 
Task 
< 
ICustomList 
< 
User 
> 
> !
GetUsersByRoleIdAsync  5
(5 6
int6 9
roleId: @
)@ A
;A B
Task 
< 
ICustomList 
< 
Role 
> 
> !
GetRolesByUserIdAsync  5
(5 6
int6 9
userId: @
)@ A
;A B
} 
} Ô
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Contracts\IUserUtilManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
	Contracts= F
{ 
public 

	interface 
IUserUtilManager %
:& '
IBusinessManager( 8
<8 9
UserUtil9 A
,A B
UserUtilRequestC R
,R S
intT W
>W X
,		( )"
IBusinessManagerUpdate		* @
<		@ A
UserUtil		A I
,		I J!
UserUtilUpdateRequest		K `
,		` a
int		b e
>		e f
{

 
Task 
< 
UserUtil 
> 
GetByUserIdAsync '
(' (
int( +
userId, 2
)2 3
;3 4
} 
} ïG
{C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\ClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
ClaimManager 
: -
!BaseBusinessManagerWithApiRequest  A
<A B

ApiRequestB L
>L M
,M N
IClaimManagerO \
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
ClaimManager 
( $
IUnitOfWorkAuthorization 4
uow5 8
,8 9
ILogger: A
<A B
ClaimManagerB N
>N O
loggerP V
,V W
IMapperX _
mapper` f
,f g
IApiRequestAccessorh {
apiRequestAccessor	| é
)
é è
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
Claim 
> 
CreateAsync &
(& '
ClaimRequest' 3
request4 ;
); <
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var   
result   
=   
Mapper   #
.  # $
Map  $ '
<  ' (
Claim  ( -
>  - .
(  . /
request  / 6
)  6 7
;  7 8
var"" 

tempResult"" 
=""  
await""! &
_uow""' +
.""+ ,
Claims"", 2
.""2 3!
GetByCustomClaimAsync""3 H
(""H I
result""I O
.""O P
CustomClaim""P [
)""[ \
;""\ ]

tempResult## 
.## 
CheckUniqueValue## +
(##+ ,"
AuthorizationConstants##, B
.##B C
CustomClaim##C N
)##N O
;##O P
_uow%% 
.%% 
Claims%% 
.%% 
Add%% 
(%%  
result%%  &
)%%& '
;%%' (
await'' 
_uow'' 
.'' 
SaveChangesAsync'' +
(''+ ,
)'', -
;''- .
return(( 
result(( 
;(( 
})) 
,)) 
new)) 
BusinessBaseRequest)) &
{))' (

MethodBase))) 3
=))4 5

MethodBase))6 @
.))@ A
GetCurrentMethod))A Q
())Q R
)))R S
}))T U
)))U V
;))V W
}** 	
public,, 
Task,, 
<,, 
Claim,, 
>,, 
UpdateAsync,, &
(,,& '
int,,' *
id,,+ -
,,,- .
ClaimRequest,,/ ;
request,,< C
),,C D
{-- 	
return.. /
#CommonOperationWithTransactionAsync.. 6
(..6 7
async..7 <
(..= >
)..> ?
=>..@ B
{// 
var00 
result00 
=00 
await00 "
GetByIdAsync00# /
(00/ 0
id000 2
)002 3
;003 4
Mapper11 
.11 
Map11 
(11 
request11 "
,11" #
result11$ *
)11* +
;11+ ,
var33 

tempResult33 
=33  
await33! &
_uow33' +
.33+ ,
Claims33, 2
.332 3!
GetByCustomClaimAsync333 H
(33H I
result33I O
.33O P
CustomClaim33P [
)33[ \
;33\ ]

tempResult44 
.44 %
CheckUniqueValueForUpdate44 4
(444 5
id445 7
,447 8"
AuthorizationConstants449 O
.44O P
CustomClaim44P [
)44[ \
;44\ ]
_uow77 
.77 
Claims77 
.77 
Update77 "
(77" #
result77# )
)77) *
;77* +
await88 
_uow88 
.88 
SaveChangesAsync88 +
(88+ ,
)88, -
;88- .
return99 
result99 
;99 
}:: 
,:: 
new:: 
BusinessBaseRequest:: &
{::' (

MethodBase::) 3
=::4 5

MethodBase::6 @
.::@ A
GetCurrentMethod::A Q
(::Q R
)::R S
}::T U
)::U V
;::V W
};; 	
public== 
Task== 
DeleteAsync== 
(==  
int==  #
id==$ &
)==& '
{>> 	
return?? /
#CommonOperationWithTransactionAsync?? 6
(??6 7
async??7 <
(??= >
)??> ?
=>??@ B
{@@ 
varAA 
resultAA 
=AA 
awaitAA "
GetByIdAsyncAA# /
(AA/ 0
idAA0 2
)AA2 3
;AA3 4
_uowBB 
.BB 
ClaimsBB 
.BB 
DeleteBB "
(BB" #
resultBB# )
)BB) *
;BB* +
awaitCC 
_uowCC 
.CC 
SaveChangesAsyncCC +
(CC+ ,
)CC, -
;CC- .
}DD 
,DD 
newDD 
BusinessBaseRequestDD &
{DD' (

MethodBaseDD) 3
=DD4 5

MethodBaseDD6 @
.DD@ A
GetCurrentMethodDDA Q
(DDQ R
)DDR S
}DDT U
)DDU V
;DDV W
}EE 	
publicGG 
TaskGG 
<GG 
ClaimGG 
>GG 
GetByIdAsyncGG '
(GG' (
intGG( +
idGG, .
)GG. /
{HH 	
returnII  
CommonOperationAsyncII '
(II' (
asyncII( -
(II. /
)II/ 0
=>II1 3
awaitII4 9
_uowII: >
.II> ?
ClaimsII? E
.IIE F
GetByIdAsyncIIF R
(IIR S
idIIS U
)IIU V
,IIV W
newIIX [
BusinessBaseRequestII\ o
{IIp q

MethodBaseIIr |
=II} ~

MethodBase	II â
.
IIâ ä
GetCurrentMethod
IIä ö
(
IIö õ
)
IIõ ú
}
IIù û
,
IIû ü
BusinessUtilMethodJJ "
.JJ" #
CheckRecordIsExistJJ# 5
,JJ5 6
GetTypeJJ7 >
(JJ> ?
)JJ? @
.JJ@ A
NameJJA E
)JJE F
;JJF G
}KK 	
publicMM 
TaskMM 
<MM 
ClaimMM 
>MM !
GetByCustomClaimAsyncMM 0
(MM0 1
stringMM1 7
customClaimMM8 C
)MMC D
{NN 	
returnOO  
CommonOperationAsyncOO '
(OO' (
asyncOO( -
(OO. /
)OO/ 0
=>OO1 3
awaitOO4 9
_uowOO: >
.OO> ?
ClaimsOO? E
.OOE F!
GetByCustomClaimAsyncOOF [
(OO[ \
customClaimOO\ g
)OOg h
,OOh i
newOOj m 
BusinessBaseRequest	OOn Å
{
OOÇ É

MethodBase
OOÑ é
=
OOè ê

MethodBase
OOë õ
.
OOõ ú
GetCurrentMethod
OOú ¨
(
OO¨ ≠
)
OO≠ Æ
}
OOØ ∞
,
OO∞ ± 
BusinessUtilMethod
OO≤ ƒ
.
OOƒ ≈ 
CheckRecordIsExist
OO≈ ◊
,
OO◊ ÿ
GetType
OOŸ ‡
(
OO‡ ·
)
OO· ‚
.
OO‚ „
Name
OO„ Á
)
OOÁ Ë
;
OOË È
}PP 	
publicRR 
TaskRR 
<RR 
ICustomListRR 
<RR  
ClaimRR  %
>RR% &
>RR& '
GetAllAsyncRR( 3
(RR3 4
intRR4 7
	pageIndexRR8 A
,RRA B
intRRC F
pageSizeRRG O
)RRO P
{SS 	
returnTT  
CommonOperationAsyncTT '
(TT' (
asyncTT( -
(TT. /
)TT/ 0
=>TT1 3
awaitTT4 9
_uowTT: >
.TT> ?
ClaimsTT? E
.TTE F
GetAllAsyncTTF Q
(TTQ R
	pageIndexTTR [
,TT[ \
pageSizeTT] e
)TTe f
,TTf g
newTTh k
BusinessBaseRequestTTl 
{
TTÄ Å

MethodBase
TTÇ å
=
TTç é

MethodBase
TTè ô
.
TTô ö
GetCurrentMethod
TTö ™
(
TT™ ´
)
TT´ ¨
}
TT≠ Æ
,
TTÆ Ø 
BusinessUtilMethod
TT∞ ¬
.
TT¬ √
CheckNothing
TT√ œ
,
TTœ –
GetType
TT— ÿ
(
TTÿ Ÿ
)
TTŸ ⁄
.
TT⁄ €
Name
TT€ ﬂ
)
TTﬂ ‡
;
TT‡ ·
}UU 	
}VV 
}WW óÅ
áC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\ClientApplicationManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class $
ClientApplicationManager )
:* +-
!BaseBusinessManagerWithApiRequest, M
<M N

ApiRequestN X
>X Y
,Y Z%
IClientApplicationManager[ t
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public $
ClientApplicationManager '
(' ($
IUnitOfWorkAuthorization( @
uowA D
,D E
ILoggerF M
<M N$
ClientApplicationManagerN f
>f g
loggerh n
,n o
IMapperp w
mapperx ~
,~ !
IApiRequestAccessor
Ä ì 
apiRequestAccessor
î ¶
)
¶ ß
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
ClientApplication %
>% &
CreateAsync' 2
(2 3$
ClientApplicationRequest3 K
requestL S
)S T
{ 	
return   /
#CommonOperationWithTransactionAsync   6
(  6 7
async  7 <
(  = >
)  > ?
=>  @ B
{!! 
var"" 
result"" 
="" 
Mapper"" #
.""# $
Map""$ '
<""' (
ClientApplication""( 9
>""9 :
("": ;
request""; B
)""B C
;""C D
var$$ 

tempResult$$ 
=$$  
await$$! &
_uow$$' +
.$$+ ,
ClientApplications$$, >
.$$> ?
GetByNameAsync$$? M
($$M N
result$$N T
.$$T U!
ClientApplicationName$$U j
)$$j k
;$$k l

tempResult%% 
.%% 
CheckUniqueValue%% +
(%%+ ,"
AuthorizationConstants%%, B
.%%B C!
ClientApplicationName%%C X
)%%X Y
;%%Y Z

tempResult'' 
='' 
await'' "
_uow''# '
.''' (
ClientApplications''( :
.'': ;
GetByCodeAsync''; I
(''I J
result''J P
.''P Q!
ClientApplicationCode''Q f
)''f g
;''g h

tempResult(( 
.(( 
CheckUniqueValue(( +
(((+ ,"
AuthorizationConstants((, B
.((B C!
ClientApplicationCode((C X
)((X Y
;((Y Z
var** 
salt** 
=** 

HashString** %
.**% &
GetSalt**& -
(**- .
)**. /
;**/ 0
var++ 
hashPassword++  
=++! "

HashString++# -
.++- .
Hash++. 2
(++2 3
result++3 9
.++9 :%
ClientApplicationPassword++: S
,++S T
salt++U Y
,++Y Z&
AuthorizationUtilConstants,, .
.,,. /$
IterationCountForHashing,,/ G
),,G H
;,,H I
result.. 
... %
ClientApplicationPassword.. 0
=..1 2
hashPassword..3 ?
;..? @
_uow00 
.00 
ClientApplications00 '
.00' (
Add00( +
(00+ ,
result00, 2
)002 3
;003 4'
CreateClientApplicationUtil22 +
(22+ ,
result22, 2
.222 3
Id223 5
,225 6
salt227 ;
)22; <
;22< =
await44 
_uow44 
.44 
SaveChangesAsync44 +
(44+ ,
)44, -
;44- .
return55 
result55 
;55 
}66 
,66 
new66 
BusinessBaseRequest66 &
{66' (

MethodBase66) 3
=664 5

MethodBase666 @
.66@ A
GetCurrentMethod66A Q
(66Q R
)66R S
}66T U
)66U V
;66V W
}77 	
public99 
Task99 
<99 
ClientApplication99 %
>99% &
UpdateAsync99' 2
(992 3
int993 6
id997 9
,999 :*
ClientApplicationUpdateRequest99; Y
request99Z a
)99a b
{:: 	
return;; /
#CommonOperationWithTransactionAsync;; 6
(;;6 7
async;;7 <
(;;= >
);;> ?
=>;;@ B
{<< 
var== 
result== 
=== 
await== "
GetByIdAsync==# /
(==/ 0
id==0 2
)==2 3
;==3 4
Mapper>> 
.>> 
Map>> 
(>> 
request>> "
,>>" #
result>>$ *
)>>* +
;>>+ ,
var@@ 

tempResult@@ 
=@@  
await@@! &
_uow@@' +
.@@+ ,
ClientApplications@@, >
.@@> ?
GetByNameAsync@@? M
(@@M N
result@@N T
.@@T U!
ClientApplicationName@@U j
)@@j k
;@@k l

tempResultAA 
.AA %
CheckUniqueValueForUpdateAA 4
(AA4 5
idAA5 7
,AA7 8"
AuthorizationConstantsAA9 O
.AAO P!
ClientApplicationNameAAP e
)AAe f
;AAf g

tempResultCC 
=CC 
awaitCC "
_uowCC# '
.CC' (
ClientApplicationsCC( :
.CC: ;
GetByCodeAsyncCC; I
(CCI J
resultCCJ P
.CCP Q!
ClientApplicationCodeCCQ f
)CCf g
;CCg h

tempResultDD 
.DD %
CheckUniqueValueForUpdateDD 4
(DD4 5
idDD5 7
,DD7 8"
AuthorizationConstantsDD9 O
.DDO P!
ClientApplicationCodeDDP e
)DDe f
;DDf g
_uowFF 
.FF 
ClientApplicationsFF '
.FF' (
UpdateFF( .
(FF. /
resultFF/ 5
)FF5 6
;FF6 7
awaitHH 
_uowHH 
.HH 
SaveChangesAsyncHH +
(HH+ ,
)HH, -
;HH- .
returnII 
resultII 
;II 
}KK 
,KK 
newKK 
BusinessBaseRequestKK &
{KK' (

MethodBaseKK) 3
=KK4 5

MethodBaseKK6 @
.KK@ A
GetCurrentMethodKKA Q
(KKQ R
)KKR S
}KKT U
)KKU V
;KKV W
}LL 	
publicNN 
TaskNN 
<NN 
ClientApplicationNN %
>NN% &0
$UpdateClientApplicationPasswordAsyncNN' K
(NNK L
intNNL O
idNNP R
,NNR S
stringNNT Z%
clientApplicationPasswordNN[ t
)NNt u
{OO 	
returnPP /
#CommonOperationWithTransactionAsyncPP 6
(PP6 7
asyncPP7 <
(PP= >
)PP> ?
=>PP@ B
{QQ 
varRR 
resultRR 
=RR 
awaitRR "
GetByIdAsyncRR# /
(RR/ 0
idRR0 2
)RR2 3
;RR3 4
varTT 
saltTT 
=TT 

HashStringTT %
.TT% &
GetSaltTT& -
(TT- .
)TT. /
;TT/ 0
varUU 
hashPasswordUU  
=UU! "

HashStringUU# -
.UU- .
HashUU. 2
(UU2 3%
clientApplicationPasswordUU3 L
,UUL M
saltUUN R
,UUR S&
AuthorizationUtilConstantsVV .
.VV. /$
IterationCountForHashingVV/ G
)VVG H
;VVH I
resultXX 
.XX %
ClientApplicationPasswordXX 0
=XX1 2
hashPasswordXX3 ?
;XX? @
_uowZZ 
.ZZ 
ClientApplicationsZZ '
.ZZ' (
UpdateZZ( .
(ZZ. /
resultZZ/ 5
)ZZ5 6
;ZZ6 7
await\\ ,
 UpdateClientApplicationUtilAsync\\ 6
(\\6 7
id\\7 9
,\\9 :
salt\\; ?
)\\? @
;\\@ A
await^^ 
_uow^^ 
.^^ 
SaveChangesAsync^^ +
(^^+ ,
)^^, -
;^^- .
return__ 
result__ 
;__ 
}`` 
,`` 
new`` 
BusinessBaseRequest`` &
{``' (

MethodBase``) 3
=``4 5

MethodBase``6 @
.``@ A
GetCurrentMethod``A Q
(``Q R
)``R S
}``T U
)``U V
;``V W
}aa 	
publiccc 
Taskcc 
DeleteAsynccc 
(cc  
intcc  #
idcc$ &
)cc& '
{dd 	
returnee /
#CommonOperationWithTransactionAsyncee 6
(ee6 7
asyncee7 <
(ee= >
)ee> ?
=>ee@ B
{ff 
vargg 
resultgg 
=gg 
awaitgg "
GetByIdAsyncgg# /
(gg/ 0
idgg0 2
)gg2 3
;gg3 4
_uowii 
.ii 
ClientApplicationsii '
.ii' (
Deleteii( .
(ii. /
resultii/ 5
)ii5 6
;ii6 7
awaitkk 
_uowkk 
.kk 
SaveChangesAsynckk +
(kk+ ,
)kk, -
;kk- .
}ll 
,ll 
newll 
BusinessBaseRequestll &
{ll' (

MethodBasell) 3
=ll4 5

MethodBasell6 @
.ll@ A
GetCurrentMethodllA Q
(llQ R
)llR S
}llT U
)llU V
;llV W
}mm 	
publicoo 
Taskoo 
<oo 
ClientApplicationoo %
>oo% &
GetByIdAsyncoo' 3
(oo3 4
intoo4 7
idoo8 :
)oo: ;
{pp 	
returnqq  
CommonOperationAsyncqq '
(qq' (
asyncqq( -
(qq. /
)qq/ 0
=>qq1 3
awaitqq4 9
_uowqq: >
.qq> ?
ClientApplicationsqq? Q
.qqQ R
GetByIdAsyncqqR ^
(qq^ _
idqq_ a
)qqa b
,qqb c
newqqd g
BusinessBaseRequestqqh {
{qq| }

MethodBase	qq~ à
=
qqâ ä

MethodBase
qqã ï
.
qqï ñ
GetCurrentMethod
qqñ ¶
(
qq¶ ß
)
qqß ®
}
qq© ™
,
qq™ ´
BusinessUtilMethodrr "
.rr" #
CheckRecordIsExistrr# 5
,rr5 6
GetTyperr7 >
(rr> ?
)rr? @
.rr@ A
NamerrA E
)rrE F
;rrF G
}ss 	
publicuu 
Taskuu 
<uu 
ClientApplicationuu %
>uu% &+
GetByClientApplicationCodeAsyncuu' F
(uuF G
stringuuG M
codeuuN R
)uuR S
{vv 	
returnww  
CommonOperationAsyncww '
(ww' (
asyncww( -
(ww. /
)ww/ 0
=>ww1 3
awaitww4 9
_uowww: >
.ww> ?
ClientApplicationsww? Q
.wwQ R
GetByCodeAsyncwwR `
(ww` a
codewwa e
)wwe f
,wwf g
newwwh k
BusinessBaseRequestwwl 
{
wwÄ Å

MethodBase
wwÇ å
=
wwç é

MethodBase
wwè ô
.
wwô ö
GetCurrentMethod
wwö ™
(
ww™ ´
)
ww´ ¨
}
ww≠ Æ
,
wwÆ Ø
BusinessUtilMethodxx "
.xx" #
CheckRecordIsExistxx# 5
,xx5 6
GetTypexx7 >
(xx> ?
)xx? @
.xx@ A
NamexxA E
)xxE F
;xxF G
}yy 	
public{{ 
Task{{ 
<{{ 
ClientApplication{{ %
>{{% &

LoginAsync{{' 1
({{1 2
string{{2 8
code{{9 =
,{{= >
string{{? E
password{{F N
){{N O
{|| 	
return}}  
CommonOperationAsync}} '
(}}' (
async}}( -
(}}. /
)}}/ 0
=>}}1 3
{~~ 
ClientApplication !
clientApplication" 3
;3 4
try
ÄÄ 
{
ÅÅ 
clientApplication
ÇÇ %
=
ÇÇ& '
await
ÇÇ( --
GetByClientApplicationCodeAsync
ÇÇ. M
(
ÇÇM N
code
ÇÇN R
)
ÇÇR S
;
ÇÇS T
}
ÉÉ 
catch
ÑÑ 
(
ÑÑ "
KeyNotFoundException
ÑÑ +
)
ÑÑ+ ,
{
ÖÖ 
throw
ÜÜ 
new
ÜÜ %
AuthenticationException
ÜÜ 5
(
ÜÜ5 6
)
ÜÜ6 7
;
ÜÜ7 8
}
áá 
var
ââ #
clientApplicationUtil
ââ )
=
ââ* +
await
ää 
_uow
ää 
.
ää $
ClientApplicationUtils
ää 5
.
ää5 6+
GetByClientApplicationIdAsync
ää6 S
(
ääS T
clientApplication
ääT e
.
ääe f
Id
ääf h
)
ääh i
;
ääi j
password
åå 
=
åå 

HashString
åå %
.
åå% &
Hash
åå& *
(
åå* +
password
åå+ 3
,
åå3 4#
clientApplicationUtil
åå5 J
.
ååJ K
SpecialValue
ååK W
,
ååW X(
AuthorizationUtilConstants
çç .
.
çç. /&
IterationCountForHashing
çç/ G
)
ççG H
;
ççH I
var
èè 
client
èè 
=
èè 
await
èè "
_uow
èè# '
.
èè' ( 
ClientApplications
èè( :
.
èè: ;'
GetByCodeAndPasswordAsync
èè; T
(
èèT U
code
èèU Y
,
èèY Z
password
èè[ c
)
èèc d
;
èèd e
if
êê 
(
êê 
client
êê 
==
êê 
null
êê "
)
êê" #
throw
êê$ )
new
êê* -%
AuthenticationException
êê. E
(
êêE F
)
êêF G
;
êêG H
return
íí 
client
íí 
;
íí 
}
ìì 
,
ìì 
new
ìì !
BusinessBaseRequest
ìì &
{
ìì' (

MethodBase
ìì) 3
=
ìì4 5

MethodBase
ìì6 @
.
ìì@ A
GetCurrentMethod
ììA Q
(
ììQ R
)
ììR S
}
ììT U
)
ììU V
;
ììV W
}
îî 	
private
òò 
async
òò 
Task
òò .
 UpdateClientApplicationUtilAsync
òò ;
(
òò; <
int
òò< ?!
clientApplicationId
òò@ S
,
òòS T
string
òòU [
salt
òò\ `
)
òò` a
{
ôô 	
var
öö #
clientApplicationUtil
öö %
=
öö& '
await
öö( -
_uow
öö. 2
.
öö2 3$
ClientApplicationUtils
öö3 I
.
ööI J+
GetByClientApplicationIdAsync
ööJ g
(
öög h!
clientApplicationId
ööh {
)
öö{ |
;
öö| }#
clientApplicationUtil
õõ !
.
õõ! "
SpecialValue
õõ" .
=
õõ/ 0
salt
õõ1 5
;
õõ5 6
_uow
úú 
.
úú $
ClientApplicationUtils
úú '
.
úú' (
Update
úú( .
(
úú. /#
clientApplicationUtil
úú/ D
)
úúD E
;
úúE F
}
ùù 	
private
üü 
void
üü )
CreateClientApplicationUtil
üü 0
(
üü0 1
int
üü1 4
id
üü5 7
,
üü7 8
string
üü9 ?
salt
üü@ D
)
üüD E
{
†† 	
var
°° #
clientApplicationUtil
°° %
=
°°& '
new
°°( +#
ClientApplicationUtil
°°, A
(
°°A B
)
°°B C
{
¢¢ !
ClientApplicationId
££ #
=
££$ %
id
££& (
,
££( )
SpecialValue
§§ 
=
§§ 
salt
§§ #
,
§§# $
}
•• 
;
•• 
_uow
ßß 
.
ßß $
ClientApplicationUtils
ßß '
.
ßß' (
Add
ßß( +
(
ßß+ ,#
clientApplicationUtil
ßß, A
)
ßßA B
;
ßßB C
}
®® 	
}
´´ 
}≠≠ Ú8
ãC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\ClientApplicationUtilManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class (
ClientApplicationUtilManager -
:. /-
!BaseBusinessManagerWithApiRequest0 Q
<Q R

ApiRequestR \
>\ ]
,] ^)
IClientApplicationUtilManager_ |
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public (
ClientApplicationUtilManager +
(+ ,$
IUnitOfWorkAuthorization, D
uowE H
,H I
ILoggerJ Q
<Q R(
ClientApplicationUtilManagerR n
>n o
loggerp v
,v w
IMapperx 
mapper
Ä Ü
,
Ü á!
IApiRequestAccessor
à õ 
apiRequestAccessor
ú Æ
)
Æ Ø
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< !
ClientApplicationUtil )
>) *
CreateAsync+ 6
(6 7(
ClientApplicationUtilRequest7 S
requestT [
)[ \
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var 
result 
= 
Mapper #
.# $
Map$ '
<' (!
ClientApplicationUtil( =
>= >
(> ?
request? F
)F G
;G H
_uow 
. "
ClientApplicationUtils +
.+ ,
Add, /
(/ 0
result0 6
)6 7
;7 8
await   
_uow   
.   
SaveChangesAsync   +
(  + ,
)  , -
;  - .
return!! 
result!! 
;!! 
}## 
,## 
new## 
BusinessBaseRequest## &
{##' (

MethodBase##) 3
=##4 5

MethodBase##6 @
.##@ A
GetCurrentMethod##A Q
(##Q R
)##R S
}##T U
)##U V
;##V W
}$$ 	
public&& 
Task&& 
<&& !
ClientApplicationUtil&& )
>&&) *
UpdateAsync&&+ 6
(&&6 7
int&&7 :
id&&; =
,&&= >.
"ClientApplicationUtilUpdateRequest&&? a
request&&b i
)&&i j
{'' 	
return(( /
#CommonOperationWithTransactionAsync(( 6
(((6 7
async((7 <
(((= >
)((> ?
=>((@ B
{)) 
var** 
result** 
=** 
await** "
GetByIdAsync**# /
(**/ 0
id**0 2
)**2 3
;**3 4
Mapper++ 
.++ 
Map++ 
(++ 
request++ "
,++" #
result++$ *
)++* +
;+++ ,
_uow-- 
.-- "
ClientApplicationUtils-- +
.--+ ,
Update--, 2
(--2 3
result--3 9
)--9 :
;--: ;
await.. 
_uow.. 
... 
SaveChangesAsync.. +
(..+ ,
).., -
;..- .
return// 
result// 
;// 
}00 
,00 
new00 
BusinessBaseRequest00 &
{00' (

MethodBase00) 3
=004 5

MethodBase006 @
.00@ A
GetCurrentMethod00A Q
(00Q R
)00R S
}00T U
)00U V
;00V W
}11 	
public33 
Task33 
DeleteAsync33 
(33  
int33  #
id33$ &
)33& '
{44 	
return55 /
#CommonOperationWithTransactionAsync55 6
(556 7
async557 <
(55= >
)55> ?
=>55@ B
{66 
var77 
result77 
=77 
await77 "
GetByIdAsync77# /
(77/ 0
id770 2
)772 3
;773 4
_uow88 
.88 "
ClientApplicationUtils88 +
.88+ ,
Delete88, 2
(882 3
result883 9
)889 :
;88: ;
await99 
_uow99 
.99 
SaveChangesAsync99 +
(99+ ,
)99, -
;99- .
}:: 
,:: 
new:: 
BusinessBaseRequest:: &
{::' (

MethodBase::) 3
=::4 5

MethodBase::6 @
.::@ A
GetCurrentMethod::A Q
(::Q R
)::R S
}::T U
)::U V
;::V W
};; 	
public== 
Task== 
<== !
ClientApplicationUtil== )
>==) *
GetByIdAsync==+ 7
(==7 8
int==8 ;
id==< >
)==> ?
{>> 	
return??  
CommonOperationAsync?? '
(??' (
async??( -
(??. /
)??/ 0
=>??1 3
await??4 9
_uow??: >
.??> ?"
ClientApplicationUtils??? U
.??U V
GetByIdAsync??V b
(??b c
id??c e
)??e f
,??f g
new??h k
BusinessBaseRequest??l 
{
??Ä Å

MethodBase
??Ç å
=
??ç é

MethodBase
??è ô
.
??ô ö
GetCurrentMethod
??ö ™
(
??™ ´
)
??´ ¨
}
??≠ Æ
,
??Æ Ø
BusinessUtilMethod@@ "
.@@" #
CheckRecordIsExist@@# 5
,@@5 6
GetType@@7 >
(@@> ?
)@@? @
.@@@ A
Name@@A E
)@@E F
;@@F G
}AA 	
publicCC 
TaskCC 
<CC !
ClientApplicationUtilCC )
>CC) *)
GetByClientApplicationIdAsyncCC+ H
(CCH I
intCCI L
clientApplicationIdCCM `
)CC` a
{DD 	
returnEE  
CommonOperationAsyncEE '
(EE' (
asyncEE( -
(EE. /
)EE/ 0
=>EE1 3
awaitEE4 9
_uowEE: >
.EE> ?"
ClientApplicationUtilsEE? U
.EEU V)
GetByClientApplicationIdAsyncEEV s
(EEs t 
clientApplicationId	EEt á
)
EEá à
,
EEà â
new
EEä ç!
BusinessBaseRequest
EEé °
{
EE¢ £

MethodBase
EE§ Æ
=
EEØ ∞

MethodBase
EE± ª
.
EEª º
GetCurrentMethod
EEº Ã
(
EEÃ Õ
)
EEÕ Œ
}
EEœ –
,
EE– —
BusinessUtilMethodFF "
.FF" #
CheckRecordIsExistFF# 5
,FF5 6
GetTypeFF7 >
(FF> ?
)FF? @
.FF@ A
NameFFA E
)FFE F
;FFF G
}GG 	
}HH 
}II ◊J
C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\RoleClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
RoleClaimManager !
:" #-
!BaseBusinessManagerWithApiRequest$ E
<E F

ApiRequestF P
>P Q
,Q R
IRoleClaimManagerS d
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
RoleClaimManager 
(  $
IUnitOfWorkAuthorization  8
uow9 <
,< =
ILogger> E
<E F
RoleClaimManagerF V
>V W
loggerX ^
,^ _
IMapper` g
mapperh n
,n o 
IApiRequestAccessor	p É 
apiRequestAccessor
Ñ ñ
)
ñ ó
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
	RoleClaim 
> 
CreateAsync *
(* +
RoleClaimRequest+ ;
request< C
)C D
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var   
result   
=   
Mapper   #
.  # $
Map  $ '
<  ' (
	RoleClaim  ( 1
>  1 2
(  2 3
request  3 :
)  : ;
;  ; <
($$ 
await$$ 
_uow$$ 
.$$ 
Roles$$ !
.$$! "
GetByIdAsync$$" .
($$. /
result$$/ 5
.$$5 6
RoleId$$6 <
)$$< =
)$$= >
.$$> ?
CheckRecordIsExist$$? Q
($$Q R
typeof$$R X
($$X Y
Role$$Y ]
)$$] ^
.$$^ _
Name$$_ c
)$$c d
;$$d e
(%% 
await%% 
_uow%% 
.%% 
Claims%% "
.%%" #
GetByIdAsync%%# /
(%%/ 0
result%%0 6
.%%6 7
ClaimId%%7 >
)%%> ?
)%%? @
.%%@ A
CheckRecordIsExist%%A S
(%%S T
typeof%%T Z
(%%Z [
Claim%%[ `
)%%` a
.%%a b
Name%%b f
)%%f g
;%%g h
var)) 

tempResult)) 
=))  
await))! &
_uow))' +
.))+ ,

RoleClaims)), 6
.))6 7&
GetByRoleIdAndClaimIdAsync))7 Q
())Q R
result))R X
.))X Y
RoleId))Y _
,))_ `
result))a g
.))g h
ClaimId))h o
)))o p
;))p q

tempResult** 
.** 
CheckUniqueValue** +
(**+ ,
GetType**, 3
(**3 4
)**4 5
.**5 6
Name**6 :
)**: ;
;**; <
_uow,, 
.,, 

RoleClaims,, 
.,,  
Add,,  #
(,,# $
result,,$ *
),,* +
;,,+ ,
await-- 
_uow-- 
.-- 
SaveChangesAsync-- +
(--+ ,
)--, -
;--- .
return.. 
result.. 
;.. 
}// 
,// 
new// 
BusinessBaseRequest// &
{//' (

MethodBase//) 3
=//4 5

MethodBase//6 @
.//@ A
GetCurrentMethod//A Q
(//Q R
)//R S
}//T U
)//U V
;//V W
}00 	
public22 
Task22 
DeleteAsync22 
(22  
int22  #
id22$ &
)22& '
{33 	
return44 /
#CommonOperationWithTransactionAsync44 6
(446 7
async447 <
(44= >
)44> ?
=>44@ B
{55 
var66 
result66 
=66 
await66 "
GetByIdAsync66# /
(66/ 0
id660 2
)662 3
;663 4
_uow77 
.77 

RoleClaims77 
.77  
Delete77  &
(77& '
result77' -
)77- .
;77. /
await88 
_uow88 
.88 
SaveChangesAsync88 +
(88+ ,
)88, -
;88- .
}99 
,99 
new99 
BusinessBaseRequest99 &
{99' (

MethodBase99) 3
=994 5

MethodBase996 @
.99@ A
GetCurrentMethod99A Q
(99Q R
)99R S
}99T U
)99U V
;99V W
}:: 	
public<< 
Task<< 
<<< 
	RoleClaim<< 
><< 
GetByIdAsync<< +
(<<+ ,
int<<, /
id<<0 2
)<<2 3
{== 	
return>>  
CommonOperationAsync>> '
(>>' (
async>>( -
(>>. /
)>>/ 0
=>>>1 3
await>>4 9
_uow>>: >
.>>> ?

RoleClaims>>? I
.>>I J
GetByIdAsync>>J V
(>>V W
id>>W Y
)>>Y Z
,>>Z [
new>>\ _
BusinessBaseRequest>>` s
{>>t u

MethodBase	>>v Ä
=
>>Å Ç

MethodBase
>>É ç
.
>>ç é
GetCurrentMethod
>>é û
(
>>û ü
)
>>ü †
}
>>° ¢
,
>>¢ £
BusinessUtilMethod?? "
.??" #
CheckRecordIsExist??# 5
,??5 6
GetType??7 >
(??> ?
)??? @
.??@ A
Name??A E
)??E F
;??F G
}@@ 	
publicBB 
TaskBB 
<BB 
boolBB 
>BB +
RolesAreAuthorizedForClaimAsyncBB 9
(BB9 :
IListBB: ?
<BB? @
RoleBB@ D
>BBD E
rolesBBF K
,BBK L
intBBM P
claimIdBBQ X
)BBX Y
{CC 	
returnDD  
CommonOperationAsyncDD '
(DD' (
asyncDD( -
(DD. /
)DD/ 0
=>DD1 3
{EE 
varFF 
resultFF 
=FF 
awaitFF "
_uowFF# '
.FF' (

RoleClaimsFF( 2
.FF2 3+
RolesAreAuthorizedForClaimAsyncFF3 R
(FFR S
rolesFFS X
,FFX Y
claimIdFFZ a
)FFa b
;FFb c
returnGG 
resultGG 
.GG 
CountGG #
>GG$ %
$numGG& '
;GG' (
}HH 
,HH 
newHH 
BusinessBaseRequestHH &
{HH' (

MethodBaseHH) 3
=HH4 5

MethodBaseHH6 @
.HH@ A
GetCurrentMethodHHA Q
(HHQ R
)HHR S
}HHT U
,HHU V
BusinessUtilMethodHHW i
.HHi j
CheckNothingHHj v
,HHv w
GetTypeHHx 
(	HH Ä
)
HHÄ Å
.
HHÅ Ç
Name
HHÇ Ü
)
HHÜ á
;
HHá à
}II 	
publicKK 
TaskKK 
<KK 
ICustomListKK 
<KK  
ClaimKK  %
>KK% &
>KK& '"
GetClaimsByRoleIdAsyncKK( >
(KK> ?
intKK? B
roleIdKKC I
)KKI J
{LL 	
returnMM  
CommonOperationAsyncMM '
(MM' (
asyncMM( -
(MM- .
)MM. /
=>MM0 2
awaitMM3 8
_uowMM9 =
.MM= >

RoleClaimsMM> H
.MMH I"
GetClaimsByRoleIdAsyncMMI _
(MM_ `
roleIdMM` f
)MMf g
,MMg h
newMMi l 
BusinessBaseRequest	MMm Ä
{
MMÅ Ç

MethodBase
MMÉ ç
=
MMé è

MethodBase
MMê ö
.
MMö õ
GetCurrentMethod
MMõ ´
(
MM´ ¨
)
MM¨ ≠
}
MMÆ Ø
,
MMØ ∞ 
BusinessUtilMethod
MM± √
.
MM√ ƒ
CheckNothing
MMƒ –
,
MM– —
GetType
MM“ Ÿ
(
MMŸ ⁄
)
MM⁄ €
.
MM€ ‹
Name
MM‹ ‡
)
MM‡ ·
;
MM· ‚
}NN 	
publicPP 
TaskPP 
<PP 
ICustomListPP 
<PP  
RolePP  $
>PP$ %
>PP% &"
GetRolesByClaimIdAsyncPP' =
(PP= >
intPP> A
claimIdPPB I
)PPI J
{QQ 	
returnRR  
CommonOperationAsyncRR '
(RR' (
asyncRR( -
(RR. /
)RR/ 0
=>RR1 3
awaitRR4 9
_uowRR: >
.RR> ?

RoleClaimsRR? I
.RRI J"
GetRolesByClaimIdAsyncRRJ `
(RR` a
claimIdRRa h
)RRh i
,RRi j
newRRk n 
BusinessBaseRequest	RRo Ç
{
RRÉ Ñ

MethodBase
RRÖ è
=
RRê ë

MethodBase
RRí ú
.
RRú ù
GetCurrentMethod
RRù ≠
(
RR≠ Æ
)
RRÆ Ø
}
RR∞ ±
,
RR± ≤ 
BusinessUtilMethod
RR≥ ≈
.
RR≈ ∆
CheckNothing
RR∆ “
,
RR“ ”
GetType
RR‘ €
(
RR€ ‹
)
RR‹ ›
.
RR› ﬁ
Name
RRﬁ ‚
)
RR‚ „
;
RR„ ‰
}SS 	
}TT 
}UU ¥P
ÖC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\RoleEntityClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class "
RoleEntityClaimManager '
:( )-
!BaseBusinessManagerWithApiRequest* K
<K L

ApiRequestL V
>V W
,W X#
IRoleEntityClaimManagerY p
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public "
RoleEntityClaimManager %
(% &$
IUnitOfWorkAuthorization& >
uow? B
,B C
ILoggerD K
<K L"
RoleEntityClaimManagerL b
>b c
loggerd j
,j k
IMapperl s
mappert z
,z { 
IApiRequestAccessor	| è 
apiRequestAccessor
ê ¢
)
¢ £
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
RoleEntityClaim #
># $
CreateAsync% 0
(0 1"
RoleEntityClaimRequest1 G
requestH O
)O P
{ 	
return   /
#CommonOperationWithTransactionAsync   6
(  6 7
async  7 <
(  = >
)  > ?
=>  @ B
{!! 
var"" 
result"" 
="" 
Mapper"" #
.""# $
Map""$ '
<""' (
RoleEntityClaim""( 7
>""7 8
(""8 9
request""9 @
)""@ A
;""A B
var$$ 

tempResult$$ 
=$$  
await$$! &
_uow$$' +
.$$+ ,
RoleEntityClaims$$, <
.$$< =%
GetByRoleIdAndEntityAsync$$= V
($$V W
result$$W ]
.$$] ^
RoleId$$^ d
,$$d e
result$$f l
.$$l m
Entity$$m s
)$$s t
;$$t u

tempResult%% 
.%% 
CheckUniqueValue%% +
(%%+ ,"
AuthorizationConstants%%, B
.%%B C
Entity%%C I
)%%I J
;%%J K
_uow'' 
.'' 
RoleEntityClaims'' %
.''% &
Add''& )
('') *
result''* 0
)''0 1
;''1 2
await(( 
_uow(( 
.(( 
SaveChangesAsync(( +
(((+ ,
)((, -
;((- .
return)) 
result)) 
;)) 
}** 
,** 
new** 
BusinessBaseRequest** &
{**' (

MethodBase**) 3
=**4 5

MethodBase**6 @
.**@ A
GetCurrentMethod**A Q
(**Q R
)**R S
}**T U
)**U V
;**V W
}++ 	
public-- 
Task-- 
<-- 
RoleEntityClaim-- #
>--# $
UpdateAsync--% 0
(--0 1
int--1 4
id--5 7
,--7 8
EntityClaimRequest--9 K
request--L S
)--S T
{.. 	
return// /
#CommonOperationWithTransactionAsync// 6
(//6 7
async//7 <
(//= >
)//> ?
=>//@ B
{00 
var11 
result11 
=11 
await11 "
GetByIdAsync11# /
(11/ 0
id110 2
)112 3
;113 4
Mapper22 
.22 
Map22 
(22 
request22 "
,22" #
result22$ *
)22* +
;22+ ,
_uow44 
.44 
RoleEntityClaims44 %
.44% &
Update44& ,
(44, -
result44- 3
)443 4
;444 5
await55 
_uow55 
.55 
SaveChangesAsync55 +
(55+ ,
)55, -
;55- .
return66 
result66 
;66 
}77 
,77 
new77 
BusinessBaseRequest77 &
{77' (

MethodBase77) 3
=774 5

MethodBase776 @
.77@ A
GetCurrentMethod77A Q
(77Q R
)77R S
}77T U
)77U V
;77V W
}88 	
public:: 
Task:: 
DeleteAsync:: 
(::  
int::  #
id::$ &
)::& '
{;; 	
return<< /
#CommonOperationWithTransactionAsync<< 6
(<<6 7
async<<7 <
(<<= >
)<<> ?
=><<@ B
{== 
var>> 
result>> 
=>> 
await>> "
GetByIdAsync>># /
(>>/ 0
id>>0 2
)>>2 3
;>>3 4
_uow?? 
.?? 
RoleEntityClaims?? %
.??% &
Delete??& ,
(??, -
result??- 3
)??3 4
;??4 5
await@@ 
_uow@@ 
.@@ 
SaveChangesAsync@@ +
(@@+ ,
)@@, -
;@@- .
}AA 
,AA 
newAA 
BusinessBaseRequestAA &
{AA' (

MethodBaseAA) 3
=AA4 5

MethodBaseAA6 @
.AA@ A
GetCurrentMethodAAA Q
(AAQ R
)AAR S
}AAT U
)AAU V
;AAV W
}BB 	
publicDD 
TaskDD 
<DD 
RoleEntityClaimDD #
>DD# $
GetByIdAsyncDD% 1
(DD1 2
intDD2 5
idDD6 8
)DD8 9
{EE 	
returnFF  
CommonOperationAsyncFF '
(FF' (
asyncFF( -
(FF. /
)FF/ 0
=>FF1 3
awaitFF4 9
_uowFF: >
.FF> ?
RoleEntityClaimsFF? O
.FFO P
GetByIdAsyncFFP \
(FF\ ]
idFF] _
)FF_ `
,FF` a
newFFb e
BusinessBaseRequestFFf y
{FFz {

MethodBase	FF| Ü
=
FFá à

MethodBase
FFâ ì
.
FFì î
GetCurrentMethod
FFî §
(
FF§ •
)
FF• ¶
}
FFß ®
,
FF® ©
BusinessUtilMethodGG "
.GG" #
CheckRecordIsExistGG# 5
,GG5 6
GetTypeGG7 >
(GG> ?
)GG? @
.GG@ A
NameGGA E
)GGE F
;GGF G
}HH 	
publicJJ 
TaskJJ 
<JJ 
boolJJ 
>JJ 1
%RolesAreAuthorizedForEntityClaimAsyncJJ ?
(JJ? @
IEnumerableJJ@ K
<JJK L
RoleJJL P
>JJP Q
rolesJJR W
,JJW X
stringJJY _
entityJJ` f
,JJf g
CrudJJh l
crudJJm q
)JJq r
{KK 	
returnLL  
CommonOperationAsyncLL '
(LL' (
asyncLL( -
(LL. /
)LL/ 0
=>LL1 3
{MM 
varNN 
resultNN 
=NN 
awaitNN "
_uowNN# '
.NN' (
RoleEntityClaimsNN( 8
.NN8 91
%RolesAreAuthorizedForEntityClaimAsyncNN9 ^
(NN^ _
rolesNN_ d
,NNd e
entityNNf l
,NNl m
crudNNn r
)NNr s
;NNs t
returnOO 
resultOO 
.OO 
CountOO #
>OO$ %
$numOO& '
;OO' (
}PP 
,PP 
newPP 
BusinessBaseRequestPP &
{PP' (

MethodBasePP) 3
=PP4 5

MethodBasePP6 @
.PP@ A
GetCurrentMethodPPA Q
(PPQ R
)PPR S
}PPT U
,PPU V
BusinessUtilMethodPPW i
.PPi j
CheckNothingPPj v
,PPv w
GetTypePPx 
(	PP Ä
)
PPÄ Å
.
PPÅ Ç
Name
PPÇ Ü
)
PPÜ á
;
PPá à
}QQ 	
publicSS 
TaskSS 
<SS 
ICustomListSS 
<SS  
RoleEntityClaimSS  /
>SS/ 0
>SS0 1
GetAllByEntityAsyncSS2 E
(SSE F
stringSSF L
entitySSM S
)SSS T
{TT 	
returnUU  
CommonOperationAsyncUU '
(UU' (
asyncUU( -
(UU. /
)UU/ 0
=>UU1 3
awaitUU4 9
_uowUU: >
.UU> ?
RoleEntityClaimsUU? O
.UUO P
GetAllByEntityAsyncUUP c
(UUc d
entityUUd j
)UUj k
,UUk l
newUUm p 
BusinessBaseRequest	UUq Ñ
{
UUÖ Ü

MethodBase
UUá ë
=
UUí ì

MethodBase
UUî û
.
UUû ü
GetCurrentMethod
UUü Ø
(
UUØ ∞
)
UU∞ ±
}
UU≤ ≥
,
UU≥ ¥ 
BusinessUtilMethod
UUµ «
.
UU« »
CheckNothing
UU» ‘
,
UU‘ ’
GetType
UU÷ ›
(
UU› ﬁ
)
UUﬁ ﬂ
.
UUﬂ ‡
Name
UU‡ ‰
)
UU‰ Â
;
UUÂ Ê
}VV 	
publicXX 
TaskXX 
<XX 
ICustomListXX 
<XX  
RoleEntityClaimXX  /
>XX/ 0
>XX0 1
GetAllByRoleIdAsyncXX2 E
(XXE F
intXXF I
roleIdXXJ P
)XXP Q
{YY 	
returnZZ  
CommonOperationAsyncZZ '
(ZZ' (
asyncZZ( -
(ZZ. /
)ZZ/ 0
=>ZZ1 3
awaitZZ4 9
_uowZZ: >
.ZZ> ?
RoleEntityClaimsZZ? O
.ZZO P
GetAllByRoleIdAsyncZZP c
(ZZc d
roleIdZZd j
)ZZj k
,ZZk l
newZZm p 
BusinessBaseRequest	ZZq Ñ
{
ZZÖ Ü

MethodBase
ZZá ë
=
ZZí ì

MethodBase
ZZî û
.
ZZû ü
GetCurrentMethod
ZZü Ø
(
ZZØ ∞
)
ZZ∞ ±
}
ZZ≤ ≥
,
ZZ≥ ¥ 
BusinessUtilMethod
ZZµ «
.
ZZ« »
CheckNothing
ZZ» ‘
,
ZZ‘ ’
GetType
ZZ÷ ›
(
ZZ› ﬁ
)
ZZﬁ ﬂ
.
ZZﬂ ‡
Name
ZZ‡ ‰
)
ZZ‰ Â
;
ZZÂ Ê
}[[ 	
}\\ 
}]] ˛D
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\RoleManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
RoleManager 
: -
!BaseBusinessManagerWithApiRequest @
<@ A

ApiRequestA K
>K L
,L M
IRoleManagerN Z
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
RoleManager 
( $
IUnitOfWorkAuthorization 3
uow4 7
,7 8
ILogger9 @
<@ A
RoleManagerA L
>L M
loggerN T
,T U
IMapperV ]
mapper^ d
,d e
IApiRequestAccessorf y
apiRequestAccessor	z å
)
å ç
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
Role 
> 
CreateAsync %
(% &
RoleRequest& 1
request2 9
)9 :
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var   
result   
=   
Mapper   #
.  # $
Map  $ '
<  ' (
Role  ( ,
>  , -
(  - .
request  . 5
)  5 6
;  6 7
var"" 

tempResult"" 
=""  
await""! &
_uow""' +
.""+ ,
Roles"", 1
.""1 2
GetByNameAsync""2 @
(""@ A
result""A G
.""G H
RoleName""H P
)""P Q
;""Q R

tempResult## 
.## 
CheckUniqueValue## +
(##+ ,"
AuthorizationConstants##, B
.##B C
RoleName##C K
)##K L
;##L M
_uow%% 
.%% 
Roles%% 
.%% 
Add%% 
(%% 
result%% %
)%%% &
;%%& '
await&& 
_uow&& 
.&& 
SaveChangesAsync&& +
(&&+ ,
)&&, -
;&&- .
return'' 
result'' 
;'' 
}(( 
,(( 
new(( 
BusinessBaseRequest(( &
{((' (

MethodBase(() 3
=((4 5

MethodBase((6 @
.((@ A
GetCurrentMethod((A Q
(((Q R
)((R S
}((T U
)((U V
;((V W
})) 	
public++ 
Task++ 
<++ 
Role++ 
>++ 
UpdateAsync++ %
(++% &
int++& )
id++* ,
,++, -
RoleRequest++. 9
request++: A
)++A B
{,, 	
return-- /
#CommonOperationWithTransactionAsync-- 6
(--6 7
async--7 <
(--= >
)--> ?
=>--@ B
{.. 
var// 
result// 
=// 
await// "
GetByIdAsync//# /
(/// 0
id//0 2
)//2 3
;//3 4
Mapper00 
.00 
Map00 
(00 
request00 "
,00" #
result00$ *
)00* +
;00+ ,
var22 

tempResult22 
=22  
await22! &
_uow22' +
.22+ ,
Roles22, 1
.221 2
GetByNameAsync222 @
(22@ A
result22A G
.22G H
RoleName22H P
)22P Q
;22Q R

tempResult33 
.33 %
CheckUniqueValueForUpdate33 4
(334 5
id335 7
,337 8"
AuthorizationConstants339 O
.33O P
RoleName33P X
)33X Y
;33Y Z
_uow55 
.55 
Roles55 
.55 
Update55 !
(55! "
result55" (
)55( )
;55) *
await66 
_uow66 
.66 
SaveChangesAsync66 +
(66+ ,
)66, -
;66- .
return77 
result77 
;77 
}88 
,88 
new88 
BusinessBaseRequest88 &
{88' (

MethodBase88) 3
=884 5

MethodBase886 @
.88@ A
GetCurrentMethod88A Q
(88Q R
)88R S
}88T U
)88U V
;88V W
}99 	
public;; 
Task;; 
DeleteAsync;; 
(;;  
int;;  #
id;;$ &
);;& '
{<< 	
return== /
#CommonOperationWithTransactionAsync== 6
(==6 7
async==7 <
(=== >
)==> ?
=>==@ B
{>> 
var?? 
result?? 
=?? 
await?? "
GetByIdAsync??# /
(??/ 0
id??0 2
)??2 3
;??3 4
_uow@@ 
.@@ 
Roles@@ 
.@@ 
Delete@@ !
(@@! "
result@@" (
)@@( )
;@@) *
awaitAA 
_uowAA 
.AA 
SaveChangesAsyncAA +
(AA+ ,
)AA, -
;AA- .
}BB 
,BB 
newBB 
BusinessBaseRequestBB &
{BB' (

MethodBaseBB) 3
=BB4 5

MethodBaseBB6 @
.BB@ A
GetCurrentMethodBBA Q
(BBQ R
)BBR S
}BBT U
)BBU V
;BBV W
}CC 	
publicEE 
TaskEE 
<EE 
RoleEE 
>EE 
GetByIdAsyncEE &
(EE& '
intEE' *
idEE+ -
)EE- .
{FF 	
returnGG  
CommonOperationAsyncGG '
(GG' (
asyncGG( -
(GG. /
)GG/ 0
=>GG1 3
awaitGG4 9
_uowGG: >
.GG> ?
RolesGG? D
.GGD E
GetByIdAsyncGGE Q
(GGQ R
idGGR T
)GGT U
,GGU V
newGGW Z
BusinessBaseRequestGG[ n
{GGo p

MethodBaseGGq {
=GG| }

MethodBase	GG~ à
.
GGà â
GetCurrentMethod
GGâ ô
(
GGô ö
)
GGö õ
}
GGú ù
,
GGù û
BusinessUtilMethodHH "
.HH" #
CheckRecordIsExistHH# 5
,HH5 6
GetTypeHH7 >
(HH> ?
)HH? @
.HH@ A
NameHHA E
)HHE F
;HHF G
}II 	
publicKK 
TaskKK 
<KK 
RoleKK 
>KK 
GetByNameAsyncKK (
(KK( )
stringKK) /
nameKK0 4
)KK4 5
{LL 	
returnMM  
CommonOperationAsyncMM '
(MM' (
asyncMM( -
(MM. /
)MM/ 0
=>MM1 3
awaitMM4 9
_uowMM: >
.MM> ?
RolesMM? D
.MMD E
GetByNameAsyncMME S
(MMS T
nameMMT X
)MMX Y
,MMY Z
newMM[ ^
BusinessBaseRequestMM_ r
{MMs t

MethodBaseMMu 
=
MMÄ Å

MethodBase
MMÇ å
.
MMå ç
GetCurrentMethod
MMç ù
(
MMù û
)
MMû ü
}
MM† °
,
MM° ¢
BusinessUtilMethodNN "
.NN" #
CheckRecordIsExistNN# 5
,NN5 6
GetTypeNN7 >
(NN> ?
)NN? @
.NN@ A
NameNNA E
)NNE F
;NNF G
}OO 	
publicQQ 
TaskQQ 
<QQ 
ICustomListQQ 
<QQ  
RoleQQ  $
>QQ$ %
>QQ% &
GetAllAsyncQQ' 2
(QQ2 3
)QQ3 4
{RR 	
returnSS  
CommonOperationAsyncSS '
(SS' (
asyncSS( -
(SS- .
)SS. /
=>SS0 2
awaitSS3 8
_uowSS9 =
.SS= >
RolesSS> C
.SSC D
GetAllAsyncSSD O
(SSO P
)SSP Q
,SSQ R
newSSS V
BusinessBaseRequestSSW j
{SSk l

MethodBaseSSm w
=SSx y

MethodBase	SSz Ñ
.
SSÑ Ö
GetCurrentMethod
SSÖ ï
(
SSï ñ
)
SSñ ó
}
SSò ô
,
SSô ö
BusinessUtilMethodTT "
.TT" #
CheckRecordIsExistTT# 5
,TT5 6
GetTypeTT7 >
(TT> ?
)TT? @
.TT@ A
NameTTA E
)TTE F
;TTF G
}UU 	
}VV 
}WW “I
C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\UserClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
UserClaimManager !
:" #-
!BaseBusinessManagerWithApiRequest$ E
<E F

ApiRequestF P
>P Q
,Q R
IUserClaimManagerS d
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
UserClaimManager 
(  $
IUnitOfWorkAuthorization  8
uow9 <
,< =
ILogger> E
<E F
UserClaimManagerF V
>V W
loggerX ^
,^ _
IMapper` g
mapperh n
,n o 
IApiRequestAccessor	p É 
apiRequestAccessor
Ñ ñ
)
ñ ó
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
	UserClaim 
> 
CreateAsync *
(* +
UserClaimRequest+ ;
request< C
)C D
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var 
result 
= 
Mapper #
.# $
Map$ '
<' (
	UserClaim( 1
>1 2
(2 3
request3 :
): ;
;; <
(## 
await## 
_uow## 
.## 
Users## !
.##! "
GetByIdAsync##" .
(##. /
result##/ 5
.##5 6
UserId##6 <
)##< =
)##= >
.##> ?
CheckRecordIsExist##? Q
(##Q R
typeof##R X
(##X Y
User##Y ]
)##] ^
.##^ _
Name##_ c
)##c d
;##d e
($$ 
await$$ 
_uow$$ 
.$$ 
Claims$$ "
.$$" #
GetByIdAsync$$# /
($$/ 0
result$$0 6
.$$6 7
ClaimId$$7 >
)$$> ?
)$$? @
.$$@ A
CheckRecordIsExist$$A S
($$S T
typeof$$T Z
($$Z [
Claim$$[ `
)$$` a
.$$a b
Name$$b f
)$$f g
;$$g h
var(( 

tempResult(( 
=((  
await((! &
_uow((' +
.((+ ,

UserClaims((, 6
.((6 7&
GetByUserIdAndClaimIdAsync((7 Q
(((Q R
result((R X
.((X Y
UserId((Y _
,((_ `
result((a g
.((g h
ClaimId((h o
)((o p
;((p q

tempResult)) 
.)) 
CheckUniqueValue)) +
())+ ,
GetType)), 3
())3 4
)))4 5
.))5 6
Name))6 :
))): ;
;)); <
_uow++ 
.++ 

UserClaims++ 
.++  
Add++  #
(++# $
result++$ *
)++* +
;+++ ,
await,, 
_uow,, 
.,, 
SaveChangesAsync,, +
(,,+ ,
),,, -
;,,- .
return-- 
result-- 
;-- 
}.. 
,.. 
new.. 
BusinessBaseRequest.. &
{..' (

MethodBase..) 3
=..4 5

MethodBase..6 @
...@ A
GetCurrentMethod..A Q
(..Q R
)..R S
}..T U
)..U V
;..V W
}// 	
public11 
Task11 
DeleteAsync11 
(11  
int11  #
id11$ &
)11& '
{22 	
return33 /
#CommonOperationWithTransactionAsync33 6
(336 7
async337 <
(33= >
)33> ?
=>33@ B
{44 
var55 
result55 
=55 
await55 "
GetByIdAsync55# /
(55/ 0
id550 2
)552 3
;553 4
_uow66 
.66 

UserClaims66 
.66  
Delete66  &
(66& '
result66' -
)66- .
;66. /
await77 
_uow77 
.77 
SaveChangesAsync77 +
(77+ ,
)77, -
;77- .
}88 
,88 
new88 
BusinessBaseRequest88 &
{88' (

MethodBase88) 3
=884 5

MethodBase886 @
.88@ A
GetCurrentMethod88A Q
(88Q R
)88R S
}88T U
)88U V
;88V W
}99 	
public;; 
Task;; 
<;; 
	UserClaim;; 
>;; 
GetByIdAsync;; +
(;;+ ,
int;;, /
id;;0 2
);;2 3
{<< 	
return==  
CommonOperationAsync== '
(==' (
async==( -
(==. /
)==/ 0
=>==1 3
await==4 9
_uow==: >
.==> ?

UserClaims==? I
.==I J
GetByIdAsync==J V
(==V W
id==W Y
)==Y Z
,==Z [
new==\ _
BusinessBaseRequest==` s
{==t u

MethodBase	==v Ä
=
==Å Ç

MethodBase
==É ç
.
==ç é
GetCurrentMethod
==é û
(
==û ü
)
==ü †
}
==° ¢
,
==¢ £
BusinessUtilMethod>> "
.>>" #
CheckRecordIsExist>># 5
,>>5 6
GetType>>7 >
(>>> ?
)>>? @
.>>@ A
Name>>A E
)>>E F
;>>F G
}?? 	
publicAA 
TaskAA 
<AA 
boolAA 
>AA )
UserIsAuthorizedForClaimAsyncAA 7
(AA7 8
intAA8 ;
userIdAA< B
,AAB C
intAAD G
claimIdAAH O
)AAO P
{BB 	
returnCC  
CommonOperationAsyncCC '
(CC' (
asyncCC( -
(CC- .
)CC. /
=>CC0 2
(CC3 4
awaitCC4 9
_uowCC: >
.CC> ?

UserClaimsCC? I
.CCI J)
UserIsAuthorizedForClaimAsyncCCJ g
(CCg h
userIdCCh n
,CCn o
claimIdCCp w
)CCw x
)CCx y
.CCy z
CountCCz 
>
CCÄ Å
$num
CCÇ É
,
CCÉ Ñ
new
CCÖ à!
BusinessBaseRequest
CCâ ú
{
CCù û

MethodBase
CCü ©
=
CC™ ´

MethodBase
CC¨ ∂
.
CC∂ ∑
GetCurrentMethod
CC∑ «
(
CC« »
)
CC» …
}
CC  À
,
CCÀ Ã 
BusinessUtilMethod
CCÕ ﬂ
.
CCﬂ ‡
CheckNothing
CC‡ Ï
,
CCÏ Ì
GetType
CCÓ ı
(
CCı ˆ
)
CCˆ ˜
.
CC˜ ¯
Name
CC¯ ¸
)
CC¸ ˝
;
CC˝ ˛
}DD 	
publicFF 
TaskFF 
<FF 
ICustomListFF 
<FF  
ClaimFF  %
>FF% &
>FF& '"
GetClaimsByUserIdAsyncFF( >
(FF> ?
intFF? B
userIdFFC I
)FFI J
{GG 	
returnHH  
CommonOperationAsyncHH '
(HH' (
asyncHH( -
(HH- .
)HH. /
=>HH0 2
awaitHH3 8
_uowHH9 =
.HH= >

UserClaimsHH> H
.HHH I"
GetClaimsByUserIdAsyncHHI _
(HH_ `
userIdHH` f
)HHf g
,HHg h
newHHi l 
BusinessBaseRequest	HHm Ä
{
HHÅ Ç

MethodBase
HHÉ ç
=
HHé è

MethodBase
HHê ö
.
HHö õ
GetCurrentMethod
HHõ ´
(
HH´ ¨
)
HH¨ ≠
}
HHÆ Ø
,
HHØ ∞ 
BusinessUtilMethod
HH± √
.
HH√ ƒ
CheckNothing
HHƒ –
,
HH– —
GetType
HH“ Ÿ
(
HHŸ ⁄
)
HH⁄ €
.
HH€ ‹
Name
HH‹ ‡
)
HH‡ ·
;
HH· ‚
}II 	
publicKK 
TaskKK 
<KK 
ICustomListKK 
<KK  
UserKK  $
>KK$ %
>KK% &"
GetUsersByClaimIdAsyncKK' =
(KK= >
intKK> A
claimIdKKB I
)KKI J
{LL 	
returnMM  
CommonOperationAsyncMM '
(MM' (
asyncMM( -
(MM. /
)MM/ 0
=>MM1 3
awaitMM4 9
_uowMM: >
.MM> ?

UserClaimsMM? I
.MMI J"
GetUsersByClaimIdAsyncMMJ `
(MM` a
claimIdMMa h
)MMh i
,MMi j
newMMk n 
BusinessBaseRequest	MMo Ç
{
MMÉ Ñ

MethodBase
MMÖ è
=
MMê ë

MethodBase
MMí ú
.
MMú ù
GetCurrentMethod
MMù ≠
(
MM≠ Æ
)
MMÆ Ø
}
MM∞ ±
,
MM± ≤ 
BusinessUtilMethod
MM≥ ≈
.
MM≈ ∆
CheckNothing
MM∆ “
,
MM“ ”
GetType
MM‘ €
(
MM€ ‹
)
MM‹ ›
.
MM› ﬁ
Name
MMﬁ ‚
)
MM‚ „
;
MM„ ‰
}NN 	
}OO 
}PP ⁄O
ÖC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\UserEntityClaimManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class "
UserEntityClaimManager '
:( )-
!BaseBusinessManagerWithApiRequest* K
<K L

ApiRequestL V
>V W
,W X#
IUserEntityClaimManagerY p
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public "
UserEntityClaimManager %
(% &$
IUnitOfWorkAuthorization& >
uow? B
,B C
ILoggerD K
<K L"
UserEntityClaimManagerL b
>b c
loggerd j
,j k
IMapperl s
mappert z
,z { 
IApiRequestAccessor	| è 
apiRequestAccessor
ê ¢
)
¢ £
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{   	
_uow!! 
=!! 
uow!! 
;!! 
}"" 	
public$$ 
Task$$ 
<$$ 
UserEntityClaim$$ #
>$$# $
CreateAsync$$% 0
($$0 1"
UserEntityClaimRequest$$1 G
request$$H O
)$$O P
{%% 	
return&& /
#CommonOperationWithTransactionAsync&& 6
(&&6 7
async&&7 <
(&&= >
)&&> ?
=>&&@ B
{'' 
var(( 
result(( 
=(( 
Mapper(( #
.((# $
Map(($ '
<((' (
UserEntityClaim((( 7
>((7 8
(((8 9
request((9 @
)((@ A
;((A B
var** 

tempResult** 
=**  
await**! &
_uow**' +
.**+ ,
UserEntityClaims**, <
.**< =%
GetByUserIdAndEntityAsync**= V
(**V W
result**W ]
.**] ^
UserId**^ d
,**d e
result**f l
.**l m
Entity**m s
)**s t
;**t u

tempResult++ 
.++ 
CheckUniqueValue++ +
(+++ ,"
AuthorizationConstants++, B
.++B C
Entity++C I
)++I J
;++J K
_uow-- 
.-- 
UserEntityClaims-- %
.--% &
Add--& )
(--) *
result--* 0
)--0 1
;--1 2
await.. 
_uow.. 
... 
SaveChangesAsync.. +
(..+ ,
).., -
;..- .
return// 
result// 
;// 
}00 
,00 
new00 
BusinessBaseRequest00 &
{00' (

MethodBase00) 3
=004 5

MethodBase006 @
.00@ A
GetCurrentMethod00A Q
(00Q R
)00R S
}00T U
)00U V
;00V W
}11 	
public33 
Task33 
<33 
UserEntityClaim33 #
>33# $
UpdateAsync33% 0
(330 1
int331 4
id335 7
,337 8
EntityClaimRequest339 K
request33L S
)33S T
{44 	
return55 /
#CommonOperationWithTransactionAsync55 6
(556 7
async557 <
(55= >
)55> ?
=>55@ B
{66 
var77 
result77 
=77 
await77 "
GetByIdAsync77# /
(77/ 0
id770 2
)772 3
;773 4
Mapper88 
.88 
Map88 
(88 
request88 "
,88" #
result88$ *
)88* +
;88+ ,
_uow:: 
.:: 
UserEntityClaims:: %
.::% &
Update::& ,
(::, -
result::- 3
)::3 4
;::4 5
await;; 
_uow;; 
.;; 
SaveChangesAsync;; +
(;;+ ,
);;, -
;;;- .
return<< 
result<< 
;<< 
}== 
,== 
new== 
BusinessBaseRequest== &
{==' (

MethodBase==) 3
===4 5

MethodBase==6 @
.==@ A
GetCurrentMethod==A Q
(==Q R
)==R S
}==T U
)==U V
;==V W
}>> 	
public@@ 
Task@@ 
DeleteAsync@@ 
(@@  
int@@  #
id@@$ &
)@@& '
{AA 	
returnBB /
#CommonOperationWithTransactionAsyncBB 6
(BB6 7
asyncBB7 <
(BB= >
)BB> ?
=>BB@ B
{CC 
varDD 
resultDD 
=DD 
awaitDD "
GetByIdAsyncDD# /
(DD/ 0
idDD0 2
)DD2 3
;DD3 4
_uowEE 
.EE 
UserEntityClaimsEE %
.EE% &
DeleteEE& ,
(EE, -
resultEE- 3
)EE3 4
;EE4 5
awaitFF 
_uowFF 
.FF 
SaveChangesAsyncFF +
(FF+ ,
)FF, -
;FF- .
}GG 
,GG 
newGG 
BusinessBaseRequestGG &
{GG' (

MethodBaseGG) 3
=GG4 5

MethodBaseGG6 @
.GG@ A
GetCurrentMethodGGA Q
(GGQ R
)GGR S
}GGT U
)GGU V
;GGV W
}HH 	
publicJJ 
TaskJJ 
<JJ 
UserEntityClaimJJ #
>JJ# $
GetByIdAsyncJJ% 1
(JJ1 2
intJJ2 5
idJJ6 8
)JJ8 9
{KK 	
returnLL  
CommonOperationAsyncLL '
(LL' (
asyncLL( -
(LL. /
)LL/ 0
=>LL1 3
awaitLL4 9
_uowLL: >
.LL> ?
UserEntityClaimsLL? O
.LLO P
GetByIdAsyncLLP \
(LL\ ]
idLL] _
)LL_ `
,LL` a
newLLb e
BusinessBaseRequestLLf y
{LLz {

MethodBase	LL| Ü
=
LLá à

MethodBase
LLâ ì
.
LLì î
GetCurrentMethod
LLî §
(
LL§ •
)
LL• ¶
}
LLß ®
,
LL® ©
BusinessUtilMethodMM "
.MM" #
CheckRecordIsExistMM# 5
,MM5 6
GetTypeMM7 >
(MM> ?
)MM? @
.MM@ A
NameMMA E
)MME F
;MMF G
}OO 	
publicQQ 
TaskQQ 
<QQ 
boolQQ 
>QQ /
#UserIsAuthorizedForEntityClaimAsyncQQ =
(QQ= >
intQQ> A
userIdQQB H
,QQH I
stringQQJ P
entityQQQ W
,QQW X
CrudQQY ]
crudQQ^ b
)QQb c
{RR 	
returnSS  
CommonOperationAsyncSS '
(SS' (
asyncSS( -
(SS. /
)SS/ 0
=>SS1 3
{TT 
varUU 
resultUU 
=UU 
awaitUU "
_uowUU# '
.UU' (
UserEntityClaimsUU( 8
.UU8 9/
#UserIsAuthorizedForEntityClaimAsyncUU9 \
(UU\ ]
userIdUU] c
,UUc d
entityUUe k
,UUk l
crudUUm q
)UUq r
;UUr s
returnVV 
resultVV 
.VV 
CountVV #
>VV$ %
$numVV& '
;VV' (
}WW 
,WW 
newWW 
BusinessBaseRequestWW &
{WW' (

MethodBaseWW) 3
=WW4 5

MethodBaseWW6 @
.WW@ A
GetCurrentMethodWWA Q
(WWQ R
)WWR S
}WWT U
,WWU V
BusinessUtilMethodWWW i
.WWi j
CheckNothingWWj v
,WWv w
GetTypeWWx 
(	WW Ä
)
WWÄ Å
.
WWÅ Ç
Name
WWÇ Ü
)
WWÜ á
;
WWá à
}XX 	
publicZZ 
TaskZZ 
<ZZ 
ICustomListZZ 
<ZZ  
UserEntityClaimZZ  /
>ZZ/ 0
>ZZ0 1
GetAllByEntityAsyncZZ2 E
(ZZE F
stringZZF L
entityZZM S
)ZZS T
{[[ 	
return\\  
CommonOperationAsync\\ '
(\\' (
async\\( -
(\\. /
)\\/ 0
=>\\1 3
await\\4 9
_uow\\: >
.\\> ?
UserEntityClaims\\? O
.\\O P
GetAllByEntityAsync\\P c
(\\c d
entity\\d j
)\\j k
,\\k l
new\\m p 
BusinessBaseRequest	\\q Ñ
{
\\Ö Ü

MethodBase
\\á ë
=
\\í ì

MethodBase
\\î û
.
\\û ü
GetCurrentMethod
\\ü Ø
(
\\Ø ∞
)
\\∞ ±
}
\\≤ ≥
,
\\≥ ¥
BusinessUtilMethod]] "
.]]" #
CheckRecordIsExist]]# 5
,]]5 6
GetType]]7 >
(]]> ?
)]]? @
.]]@ A
Name]]A E
)]]E F
;]]F G
}^^ 	
public`` 
Task`` 
<`` 
ICustomList`` 
<``  
UserEntityClaim``  /
>``/ 0
>``0 1
GetAllByUserIdAsync``2 E
(``E F
int``F I
userId``J P
)``P Q
{aa 	
returnbb  
CommonOperationAsyncbb '
(bb' (
asyncbb( -
(bb. /
)bb/ 0
=>bb1 3
awaitbb4 9
_uowbb: >
.bb> ?
UserEntityClaimsbb? O
.bbO P
GetAllByUserIdAsyncbbP c
(bbc d
userIdbbd j
)bbj k
,bbk l
newbbm p 
BusinessBaseRequest	bbq Ñ
{
bbÖ Ü

MethodBase
bbá ë
=
bbí ì

MethodBase
bbî û
.
bbû ü
GetCurrentMethod
bbü Ø
(
bbØ ∞
)
bb∞ ±
}
bb≤ ≥
,
bb≥ ¥
BusinessUtilMethodcc "
.cc" #
CheckRecordIsExistcc# 5
,cc5 6
GetTypecc7 >
(cc> ?
)cc? @
.cc@ A
NameccA E
)ccE F
;ccF G
}dd 	
}ee 
}ff ∂ó
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\UserManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
UserManager 
: -
!BaseBusinessManagerWithApiRequest @
<@ A

ApiRequestA K
>K L
,L M
IUserManagerN Z
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
UserManager 
( $
IUnitOfWorkAuthorization 3
uow4 7
,7 8
ILogger9 @
<@ A
UserManagerA L
>L M
loggerN T
,T U
IMapperV ]
mapper^ d
,d e
IApiRequestAccessorf y
apiRequestAccessor	z å
)
å ç
:   
base   
(   
logger   
,   
mapper   !
,  ! "
apiRequestAccessor  # 5
)  5 6
{!! 	
_uow"" 
="" 
uow"" 
;"" 
}## 	
public%% 
Task%% 
<%% 
User%% 
>%% 
CreateAsync%% %
(%%% &
UserRequest%%& 1
request%%2 9
)%%9 :
{&& 	
return'' /
#CommonOperationWithTransactionAsync'' 6
(''6 7
async''7 <
(''= >
)''> ?
=>''@ B
{(( 
var)) 
result)) 
=)) 
Mapper)) #
.))# $
Map))$ '
<))' (
User))( ,
>)), -
())- .
request)). 5
)))5 6
;))6 7
var++ 

tempResult++ 
=++  
await++! &
_uow++' +
.+++ ,
Users++, 1
.++1 2
GetByUserNameAsync++2 D
(++D E
result++E K
.++K L
UserName++L T
)++T U
;++U V

tempResult,, 
.,, 
CheckUniqueValue,, +
(,,+ ,"
AuthorizationConstants,,, B
.,,B C
UserName,,C K
),,K L
;,,L M

tempResult.. 
=.. 
await.. "
_uow..# '
...' (
Users..( -
...- .
GetByEmailAsync... =
(..= >
result..> D
...D E
Email..E J
)..J K
;..K L

tempResult// 
.// 
CheckUniqueValue// +
(//+ ,"
AuthorizationConstants//, B
.//B C
Email//C H
)//H I
;//I J
var11 
salt11 
=11 

HashString11 %
.11% &
GetSalt11& -
(11- .
)11. /
;11/ 0
var22 
hashPassword22  
=22! "

HashString22# -
.22- .
Hash22. 2
(222 3
result223 9
.229 :
Password22: B
,22B C
salt22D H
,22H I&
AuthorizationUtilConstants33 .
.33. /$
IterationCountForHashing33/ G
)33G H
;33H I
result55 
.55 
Password55 
=55  !
hashPassword55" .
;55. /
_uow77 
.77 
Users77 
.77 
Add77 
(77 
result77 %
)77% &
;77& '
CreateUserUtil99 
(99 
result99 %
.99% &
Id99& (
,99( )
salt99* .
)99. /
;99/ 0
await;; 
_uow;; 
.;; 
SaveChangesAsync;; +
(;;+ ,
);;, -
;;;- .
return<< 
result<< 
;<< 
}== 
,== 
new== 
BusinessBaseRequest== &
{==' (

MethodBase==) 3
===4 5

MethodBase==6 @
.==@ A
GetCurrentMethod==A Q
(==Q R
)==R S
}==T U
)==U V
;==V W
}>> 	
public@@ 
Task@@ 
<@@ 
User@@ 
>@@ 
UpdateUserNameAsync@@ -
(@@- .
int@@. 1
id@@2 4
,@@4 5
string@@6 <
userName@@= E
)@@E F
{AA 	
returnBB /
#CommonOperationWithTransactionAsyncBB 6
(BB6 7
asyncBB7 <
(BB= >
)BB> ?
=>BB@ B
{CC 
varDD 
resultDD 
=DD 
awaitDD "
GetByIdAsyncDD# /
(DD/ 0
idDD0 2
)DD2 3
;DD3 4
resultEE 
.EE 
UserNameEE 
=EE  !
userNameEE" *
;EE* +
varGG 

tempResultGG 
=GG  
awaitGG! &
_uowGG' +
.GG+ ,
UsersGG, 1
.GG1 2
GetByUserNameAsyncGG2 D
(GGD E
resultGGE K
.GGK L
UserNameGGL T
)GGT U
;GGU V

tempResultHH 
.HH %
CheckUniqueValueForUpdateHH 4
(HH4 5
idHH5 7
,HH7 8"
AuthorizationConstantsHH9 O
.HHO P
UserNameHHP X
)HHX Y
;HHY Z
_uowJJ 
.JJ 
UsersJJ 
.JJ 
UpdateJJ !
(JJ! "
resultJJ" (
)JJ( )
;JJ) *
awaitKK 
_uowKK 
.KK 
SaveChangesAsyncKK +
(KK+ ,
)KK, -
;KK- .
returnLL 
resultLL 
;LL 
}MM 
,MM 
newMM 
BusinessBaseRequestMM &
{MM' (

MethodBaseMM) 3
=MM4 5

MethodBaseMM6 @
.MM@ A
GetCurrentMethodMMA Q
(MMQ R
)MMR S
}MMT U
)MMU V
;MMV W
}NN 	
publicPP 
TaskPP 
<PP 
UserPP 
>PP 
UpdatePasswordAsyncPP -
(PP- .
intPP. 1
idPP2 4
,PP4 5
stringPP6 <
passwordPP= E
)PPE F
{QQ 	
returnRR /
#CommonOperationWithTransactionAsyncRR 6
(RR6 7
asyncRR7 <
(RR= >
)RR> ?
=>RR@ B
{SS 
varTT 
resultTT 
=TT 
awaitTT "
GetByIdAsyncTT# /
(TT/ 0
idTT0 2
)TT2 3
;TT3 4
varWW 
saltWW 
=WW 

HashStringWW %
.WW% &
GetSaltWW& -
(WW- .
)WW. /
;WW/ 0
varXX 
hashPasswordXX  
=XX! "

HashStringXX# -
.XX- .
HashXX. 2
(XX2 3
passwordXX3 ;
,XX; <
saltXX= A
,XXA B&
AuthorizationUtilConstantsXXC ]
.XX] ^$
IterationCountForHashingXX^ v
)XXv w
;XXw x
resultZZ 
.ZZ 
PasswordZZ 
=ZZ  !
hashPasswordZZ" .
;ZZ. /
_uow\\ 
.\\ 
Users\\ 
.\\ 
Update\\ !
(\\! "
result\\" (
)\\( )
;\\) *
await^^ 
UpdateUserUtilAsync^^ )
(^^) *
id^^* ,
,^^, -
salt^^. 2
)^^2 3
;^^3 4
await`` 
_uow`` 
.`` 
SaveChangesAsync`` +
(``+ ,
)``, -
;``- .
returnaa 
resultaa 
;aa 
}bb 
,bb 
newbb 
BusinessBaseRequestbb &
{bb' (

MethodBasebb) 3
=bb4 5

MethodBasebb6 @
.bb@ A
GetCurrentMethodbbA Q
(bbQ R
)bbR S
}bbT U
)bbU V
;bbV W
}cc 	
publicee 
Taskee 
<ee 
Useree 
>ee 
UpdateEmailAsyncee *
(ee* +
intee+ .
idee/ 1
,ee1 2
stringee3 9
emailee: ?
)ee? @
{ff 	
returngg /
#CommonOperationWithTransactionAsyncgg 6
(gg6 7
asyncgg7 <
(gg= >
)gg> ?
=>gg@ B
{hh 
varii 
resultii 
=ii 
awaitii "
GetByIdAsyncii# /
(ii/ 0
idii0 2
)ii2 3
;ii3 4
resultjj 
.jj 
Emailjj 
=jj 
emailjj $
;jj$ %
varll 

tempResultll 
=ll  
awaitll! &
_uowll' +
.ll+ ,
Usersll, 1
.ll1 2
GetByEmailAsyncll2 A
(llA B
resultllB H
.llH I
EmailllI N
)llN O
;llO P

tempResultmm 
.mm %
CheckUniqueValueForUpdatemm 4
(mm4 5
idmm5 7
,mm7 8"
AuthorizationConstantsmm9 O
.mmO P
EmailmmP U
)mmU V
;mmV W
_uowoo 
.oo 
Usersoo 
.oo 
Updateoo !
(oo! "
resultoo" (
)oo( )
;oo) *
awaitpp 
_uowpp 
.pp 
SaveChangesAsyncpp +
(pp+ ,
)pp, -
;pp- .
returnqq 
resultqq 
;qq 
}rr 
,rr 
newrr 
BusinessBaseRequestrr &
{rr' (

MethodBaserr) 3
=rr4 5

MethodBaserr6 @
.rr@ A
GetCurrentMethodrrA Q
(rrQ R
)rrR S
}rrT U
)rrU V
;rrV W
}ss 	
publicuu 
Taskuu 
DeleteAsyncuu 
(uu  
intuu  #
iduu$ &
)uu& '
{vv 	
returnww /
#CommonOperationWithTransactionAsyncww 6
(ww6 7
asyncww7 <
(ww= >
)ww> ?
=>ww@ B
{xx 
varyy 
resultyy 
=yy 
awaityy "
GetByIdAsyncyy# /
(yy/ 0
idyy0 2
)yy2 3
;yy3 4
_uowzz 
.zz 
Userszz 
.zz 
Deletezz !
(zz! "
resultzz" (
)zz( )
;zz) *
await{{ 
_uow{{ 
.{{ 
SaveChangesAsync{{ +
({{+ ,
){{, -
;{{- .
}|| 
,|| 
new|| 
BusinessBaseRequest|| &
{||' (

MethodBase||) 3
=||4 5

MethodBase||6 @
.||@ A
GetCurrentMethod||A Q
(||Q R
)||R S
}||T U
)||U V
;||V W
}}} 	
public 
Task 
< 
User 
> 

LoginAsync $
($ %
string% +
userName, 4
,4 5
string6 <
password= E
)E F
{
ÄÄ 	
return
ÅÅ "
CommonOperationAsync
ÅÅ '
(
ÅÅ' (
async
ÅÅ( -
(
ÅÅ. /
)
ÅÅ/ 0
=>
ÅÅ1 3
{
ÇÇ 
var
ÉÉ 
user
ÉÉ 
=
ÉÉ 
await
ÉÉ  
_uow
ÉÉ! %
.
ÉÉ% &
Users
ÉÉ& +
.
ÉÉ+ , 
GetByUserNameAsync
ÉÉ, >
(
ÉÉ> ?
userName
ÉÉ? G
)
ÉÉG H
;
ÉÉH I
if
ÑÑ 
(
ÑÑ 
user
ÑÑ 
==
ÑÑ 
null
ÑÑ  
)
ÑÑ  !
throw
ÑÑ" '
new
ÑÑ( +%
AuthenticationException
ÑÑ, C
(
ÑÑC D
)
ÑÑD E
;
ÑÑE F
var
áá 
userUtil
áá 
=
áá 
await
áá $
_uow
áá% )
.
áá) *
	UserUtils
áá* 3
.
áá3 4
GetByUserIdAsync
áá4 D
(
ááD E
user
ááE I
.
ááI J
Id
ááJ L
)
ááL M
;
ááM N
var
àà 
hashed
àà 
=
àà 

HashString
àà '
.
àà' (
Hash
àà( ,
(
àà, -
password
àà- 5
,
àà5 6
userUtil
àà7 ?
.
àà? @
SpecialValue
àà@ L
,
ààL M(
AuthorizationUtilConstants
ââ .
.
ââ. /&
IterationCountForHashing
ââ/ G
)
ââG H
;
ââH I
password
ää 
=
ää 
hashed
ää !
;
ää! "
var
çç 
result
çç 
=
çç 
await
çç "
_uow
çç# '
.
çç' (
Users
çç( -
.
çç- .+
GetByUserNameAndPasswordAsync
çç. K
(
ççK L
userName
ççL T
,
ççT U
password
ççV ^
)
çç^ _
;
çç_ `
if
éé 
(
éé 
result
éé 
==
éé 
null
éé "
)
éé" #
throw
éé$ )
new
éé* -%
AuthenticationException
éé. E
(
ééE F
)
ééF G
;
ééG H
return
êê 
result
êê 
;
êê 
}
ëë 
,
ëë 
new
ëë !
BusinessBaseRequest
ëë &
{
ëë' (

MethodBase
ëë) 3
=
ëë4 5

MethodBase
ëë6 @
.
ëë@ A
GetCurrentMethod
ëëA Q
(
ëëQ R
)
ëëR S
}
ëëT U
)
ëëU V
;
ëëV W
}
íí 	
public
îî 
Task
îî 
<
îî 
User
îî 
>
îî 
GetByIdAsync
îî &
(
îî& '
int
îî' *
id
îî+ -
)
îî- .
{
ïï 	
return
ññ "
CommonOperationAsync
ññ '
(
ññ' (
async
ññ( -
(
ññ. /
)
ññ/ 0
=>
ññ1 3
await
ññ4 9
_uow
ññ: >
.
ññ> ?
Users
ññ? D
.
ññD E
GetByIdAsync
ññE Q
(
ññQ R
id
ññR T
)
ññT U
,
ññU V
new
ññW Z!
BusinessBaseRequest
ññ[ n
{
ñño p

MethodBase
ññq {
=
ññ| }

MethodBaseññ~ à
.ññà â 
GetCurrentMethodññâ ô
(ññô ö
)ññö õ
}ññú ù
,ññù û 
BusinessUtilMethod
óó "
.
óó" # 
CheckRecordIsExist
óó# 5
,
óó5 6
GetType
óó7 >
(
óó> ?
)
óó? @
.
óó@ A
Name
óóA E
)
óóE F
;
óóF G
}
òò 	
public
öö 
Task
öö 
<
öö 
User
öö 
>
öö  
GetByUserNameAsync
öö ,
(
öö, -
string
öö- 3
userName
öö4 <
)
öö< =
{
õõ 	
return
úú "
CommonOperationAsync
úú '
(
úú' (
async
úú( -
(
úú. /
)
úú/ 0
=>
úú1 3
await
úú4 9
_uow
úú: >
.
úú> ?
Users
úú? D
.
úúD E 
GetByUserNameAsync
úúE W
(
úúW X
userName
úúX `
)
úú` a
,
úúa b
new
úúc f!
BusinessBaseRequest
úúg z
{
úú{ |

MethodBaseúú} á
=úúà â

MethodBaseúúä î
.úúî ï 
GetCurrentMethodúúï •
(úú• ¶
)úú¶ ß
}úú® ©
,úú© ™ 
BusinessUtilMethod
ùù "
.
ùù" # 
CheckRecordIsExist
ùù# 5
,
ùù5 6
GetType
ùù7 >
(
ùù> ?
)
ùù? @
.
ùù@ A
Name
ùùA E
)
ùùE F
;
ùùF G
}
ûû 	
public
†† 
Task
†† 
<
†† 
User
†† 
>
†† 
GetByEmailAsync
†† )
(
††) *
string
††* 0
email
††1 6
)
††6 7
{
°° 	
return
¢¢ "
CommonOperationAsync
¢¢ '
(
¢¢' (
async
¢¢( -
(
¢¢. /
)
¢¢/ 0
=>
¢¢1 3
await
¢¢4 9
_uow
¢¢: >
.
¢¢> ?
Users
¢¢? D
.
¢¢D E
GetByEmailAsync
¢¢E T
(
¢¢T U
email
¢¢U Z
)
¢¢Z [
,
¢¢[ \
new
¢¢] `!
BusinessBaseRequest
¢¢a t
{
¢¢u v

MethodBase¢¢w Å
=¢¢Ç É

MethodBase¢¢Ñ é
.¢¢é è 
GetCurrentMethod¢¢è ü
(¢¢ü †
)¢¢† °
}¢¢¢ £
,¢¢£ § 
BusinessUtilMethod
££ "
.
££" # 
CheckRecordIsExist
££# 5
,
££5 6
GetType
££7 >
(
££> ?
)
££? @
.
££@ A
Name
££A E
)
££E F
;
££F G
}
§§ 	
public
¶¶ 
Task
¶¶ 
<
¶¶ 
ICustomList
¶¶ 
<
¶¶  
User
¶¶  $
>
¶¶$ %
>
¶¶% &
GetAllAsync
¶¶' 2
(
¶¶2 3
)
¶¶3 4
{
ßß 	
return
®® "
CommonOperationAsync
®® '
(
®®' (
async
®®( -
(
®®. /
)
®®/ 0
=>
®®1 3
await
®®4 9
_uow
®®: >
.
®®> ?
Users
®®? D
.
®®D E
GetAllAsync
®®E P
(
®®P Q
)
®®Q R
,
®®R S
new
®®T W!
BusinessBaseRequest
®®X k
{
®®l m

MethodBase
®®n x
=
®®y z

MethodBase®®{ Ö
.®®Ö Ü 
GetCurrentMethod®®Ü ñ
(®®ñ ó
)®®ó ò
}®®ô ö
,®®ö õ"
BusinessUtilMethod®®ú Æ
.®®Æ Ø
CheckNothing®®Ø ª
,®®ª º
GetType®®Ω ƒ
(®®ƒ ≈
)®®≈ ∆
.®®∆ «
Name®®« À
)®®À Ã
;®®Ã Õ
}
©© 	
private
¨¨ 
async
¨¨ 
Task
¨¨ !
UpdateUserUtilAsync
¨¨ .
(
¨¨. /
int
¨¨/ 2
userId
¨¨3 9
,
¨¨9 :
string
¨¨; A
salt
¨¨B F
)
¨¨F G
{
≠≠ 	
var
ÆÆ 
userUtil
ÆÆ 
=
ÆÆ 
await
ÆÆ  
_uow
ÆÆ! %
.
ÆÆ% &
	UserUtils
ÆÆ& /
.
ÆÆ/ 0
GetByUserIdAsync
ÆÆ0 @
(
ÆÆ@ A
userId
ÆÆA G
)
ÆÆG H
;
ÆÆH I
userUtil
ØØ 
.
ØØ 
SpecialValue
ØØ !
=
ØØ" #
salt
ØØ$ (
;
ØØ( )
_uow
∞∞ 
.
∞∞ 
	UserUtils
∞∞ 
.
∞∞ 
Update
∞∞ !
(
∞∞! "
userUtil
∞∞" *
)
∞∞* +
;
∞∞+ ,
}
±± 	
private
≥≥ 
void
≥≥ 
CreateUserUtil
≥≥ #
(
≥≥# $
int
≥≥$ '
id
≥≥( *
,
≥≥* +
string
≥≥, 2
salt
≥≥3 7
)
≥≥7 8
{
¥¥ 	
var
µµ 
userUtil
µµ 
=
µµ 
new
µµ 
UserUtil
µµ '
{
∂∂ 
UserId
∑∑ 
=
∑∑ 
id
∑∑ 
,
∑∑ 
SpecialValue
∏∏ 
=
∏∏ 
salt
∏∏ #
,
∏∏# $
}
ππ 
;
ππ 
_uow
∫∫ 
.
∫∫ 
	UserUtils
∫∫ 
.
∫∫ 
Add
∫∫ 
(
∫∫ 
userUtil
∫∫ '
)
∫∫' (
;
∫∫( )
}
ªª 	
}
ΩΩ 
}ææ ÄA
~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\UserRoleManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
UserRoleManager  
:! "-
!BaseBusinessManagerWithApiRequest# D
<D E

ApiRequestE O
>O P
,P Q
IUserRoleManagerR b
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
UserRoleManager 
( $
IUnitOfWorkAuthorization 7
uow8 ;
,; <
ILogger= D
<D E
UserRoleManagerE T
>T U
loggerV \
,\ ]
IMapper^ e
mapperf l
,l m 
IApiRequestAccessor	n Å 
apiRequestAccessor
Ç î
)
î ï
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
UserRole 
> 
CreateAsync )
() *
UserRoleRequest* 9
request: A
)A B
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var 
result 
= 
new  
UserRole! )
() *
)* +
{   
UserId!! 
=!! 
request!! $
.!!$ %
UserId!!% +
,!!+ ,
RoleId"" 
="" 
request"" $
.""$ %
RoleId""% +
,""+ ,
}## 
;## 
('' 
await'' 
_uow'' 
.'' 
Roles'' !
.''! "
GetByIdAsync''" .
(''. /
result''/ 5
.''5 6
RoleId''6 <
)''< =
)''= >
.''> ?
CheckRecordIsExist''? Q
(''Q R
typeof''R X
(''X Y
Role''Y ]
)''] ^
.''^ _
Name''_ c
)''c d
;''d e
((( 
await(( 
_uow(( 
.(( 
Users(( !
.((! "
GetByIdAsync((" .
(((. /
result((/ 5
.((5 6
UserId((6 <
)((< =
)((= >
.((> ?
CheckRecordIsExist((? Q
(((Q R
typeof((R X
(((X Y
User((Y ]
)((] ^
.((^ _
Name((_ c
)((c d
;((d e
var,, 

tempResult,, 
=,,  
await,,! &
_uow,,' +
.,,+ ,
	UserRoles,,, 5
.,,5 6%
GetByUserIdAndRoleIdAsync,,6 O
(,,O P
result,,P V
.,,V W
UserId,,W ]
,,,] ^
result,,_ e
.,,e f
RoleId,,f l
),,l m
;,,m n

tempResult-- 
.-- 
CheckUniqueValue-- +
(--+ ,
GetType--, 3
(--3 4
)--4 5
.--5 6
Name--6 :
)--: ;
;--; <
_uow// 
.// 
	UserRoles// 
.// 
Add// "
(//" #
result//# )
)//) *
;//* +
await00 
_uow00 
.00 
SaveChangesAsync00 +
(00+ ,
)00, -
;00- .
return11 
result11 
;11 
}22 
,22 
new22 
BusinessBaseRequest22 &
{22' (

MethodBase22) 3
=224 5

MethodBase226 @
.22@ A
GetCurrentMethod22A Q
(22Q R
)22R S
}22T U
)22U V
;22V W
}33 	
public55 
Task55 
DeleteAsync55 
(55  
int55  #
id55$ &
)55& '
{66 	
return77 /
#CommonOperationWithTransactionAsync77 6
(776 7
async777 <
(77= >
)77> ?
=>77@ B
{88 
var99 
result99 
=99 
await99 "
GetByIdAsync99# /
(99/ 0
id990 2
)992 3
;993 4
_uow:: 
.:: 
	UserRoles:: 
.:: 
Delete:: %
(::% &
result::& ,
)::, -
;::- .
await;; 
_uow;; 
.;; 
SaveChangesAsync;; +
(;;+ ,
);;, -
;;;- .
}<< 
,<< 
new<< 
BusinessBaseRequest<< &
{<<' (

MethodBase<<) 3
=<<4 5

MethodBase<<6 @
.<<@ A
GetCurrentMethod<<A Q
(<<Q R
)<<R S
}<<T U
)<<U V
;<<V W
}== 	
public?? 
Task?? 
<?? 
UserRole?? 
>?? 
GetByIdAsync?? *
(??* +
int??+ .
id??/ 1
)??1 2
{@@ 	
returnAA  
CommonOperationAsyncAA '
(AA' (
asyncAA( -
(AA. /
)AA/ 0
=>AA1 3
awaitAA4 9
_uowAA: >
.AA> ?
	UserRolesAA? H
.AAH I
GetByIdAsyncAAI U
(AAU V
idAAV X
)AAX Y
,AAY Z
newAA[ ^
BusinessBaseRequestAA_ r
{AAs t

MethodBaseAAu 
=
AAÄ Å

MethodBase
AAÇ å
.
AAå ç
GetCurrentMethod
AAç ù
(
AAù û
)
AAû ü
}
AA† °
,
AA° ¢
BusinessUtilMethodBB "
.BB" #
CheckRecordIsExistBB# 5
,BB5 6
GetTypeBB7 >
(BB> ?
)BB? @
.BB@ A
NameBBA E
)BBE F
;BBF G
}CC 	
publicEE 
TaskEE 
<EE 
ICustomListEE 
<EE  
UserEE  $
>EE$ %
>EE% &!
GetUsersByRoleIdAsyncEE' <
(EE< =
intEE= @
roleIdEEA G
)EEG H
{FF 	
returnGG  
CommonOperationAsyncGG '
(GG' (
asyncGG( -
(GG. /
)GG/ 0
=>GG1 3
awaitGG4 9
_uowGG: >
.GG> ?
	UserRolesGG? H
.GGH I!
GetUsersByRoleIdAsyncGGI ^
(GG^ _
roleIdGG_ e
)GGe f
,GGf g
newGGh k
BusinessBaseRequestGGl 
{
GGÄ Å

MethodBase
GGÇ å
=
GGç é

MethodBase
GGè ô
.
GGô ö
GetCurrentMethod
GGö ™
(
GG™ ´
)
GG´ ¨
}
GG≠ Æ
,
GGÆ Ø 
BusinessUtilMethod
GG∞ ¬
.
GG¬ √
CheckNothing
GG√ œ
,
GGœ –
GetType
GG— ÿ
(
GGÿ Ÿ
)
GGŸ ⁄
.
GG⁄ €
Name
GG€ ﬂ
)
GGﬂ ‡
;
GG‡ ·
}HH 	
publicJJ 
TaskJJ 
<JJ 
ICustomListJJ 
<JJ  
RoleJJ  $
>JJ$ %
>JJ% &!
GetRolesByUserIdAsyncJJ' <
(JJ< =
intJJ= @
userIdJJA G
)JJG H
{KK 	
returnLL  
CommonOperationAsyncLL '
(LL' (
asyncLL( -
(LL. /
)LL/ 0
=>LL1 3
awaitLL4 9
_uowLL: >
.LL> ?
	UserRolesLL? H
.LLH I!
GetRolesByUserIdAsyncLLI ^
(LL^ _
userIdLL_ e
)LLe f
,LLf g
newLLh k
BusinessBaseRequestLLl 
{
LLÄ Å

MethodBase
LLÇ å
=
LLç é

MethodBase
LLè ô
.
LLô ö
GetCurrentMethod
LLö ™
(
LL™ ´
)
LL´ ¨
}
LL≠ Æ
,
LLÆ Ø 
BusinessUtilMethod
LL∞ ¬
.
LL¬ √
CheckNothing
LL√ œ
,
LLœ –
GetType
LL— ÿ
(
LLÿ Ÿ
)
LLŸ ⁄
.
LL⁄ €
Name
LL€ ﬂ
)
LLﬂ ‡
;
LL‡ ·
}MM 	
}NN 
}OO À6
~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Business\Managers\UserUtilManager.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Business4 <
.< =
Managers= E
{ 
public 

class 
UserUtilManager  
:! "-
!BaseBusinessManagerWithApiRequest# D
<D E

ApiRequestE O
>O P
,P Q
IUserUtilManagerR b
{ 
private 
readonly $
IUnitOfWorkAuthorization 1
_uow2 6
;6 7
public 
UserUtilManager 
( $
IUnitOfWorkAuthorization 7
uow8 ;
,; <
ILogger= D
<D E
UserUtilManagerE T
>T U
loggerV \
,\ ]
IMapper^ e
mapperf l
,l m 
IApiRequestAccessor	n Å 
apiRequestAccessor
Ç î
)
î ï
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
UserUtil 
> 
CreateAsync )
() *
UserUtilRequest* 9
request: A
)A B
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var 
result 
= 
Mapper #
.# $
Map$ '
<' (
UserUtil( 0
>0 1
(1 2
request2 9
)9 :
;: ;
_uow 
. 
	UserUtils 
. 
Add "
(" #
result# )
)) *
;* +
await 
_uow 
. 
SaveChangesAsync +
(+ ,
), -
;- .
return   
result   
;   
}!! 
,!! 
new!! 
BusinessBaseRequest!! &
{!!' (

MethodBase!!) 3
=!!4 5

MethodBase!!6 @
.!!@ A
GetCurrentMethod!!A Q
(!!Q R
)!!R S
}!!T U
)!!U V
;!!V W
}"" 	
public$$ 
Task$$ 
<$$ 
UserUtil$$ 
>$$ 
UpdateAsync$$ )
($$) *
int$$* -
id$$. 0
,$$0 1!
UserUtilUpdateRequest$$2 G
request$$H O
)$$O P
{%% 	
return&& /
#CommonOperationWithTransactionAsync&& 6
(&&6 7
async&&7 <
(&&= >
)&&> ?
=>&&@ B
{'' 
var(( 
result(( 
=(( 
await(( "
GetByIdAsync((# /
(((/ 0
id((0 2
)((2 3
;((3 4
Mapper)) 
.)) 
Map)) 
()) 
request)) "
,))" #
result))$ *
)))* +
;))+ ,
_uow** 
.** 
	UserUtils** 
.** 
Update** %
(**% &
result**& ,
)**, -
;**- .
await++ 
_uow++ 
.++ 
SaveChangesAsync++ +
(+++ ,
)++, -
;++- .
return,, 
result,, 
;,, 
}-- 
,-- 
new-- 
BusinessBaseRequest-- &
{--' (

MethodBase--) 3
=--4 5

MethodBase--6 @
.--@ A
GetCurrentMethod--A Q
(--Q R
)--R S
}--T U
)--U V
;--V W
}.. 	
public00 
Task00 
DeleteAsync00 
(00  
int00  #
id00$ &
)00& '
{11 	
return22 /
#CommonOperationWithTransactionAsync22 6
(226 7
async227 <
(22= >
)22> ?
=>22@ B
{33 
var44 
result44 
=44 
await44 "
GetByIdAsync44# /
(44/ 0
id440 2
)442 3
;443 4
_uow55 
.55 
	UserUtils55 
.55 
Delete55 %
(55% &
result55& ,
)55, -
;55- .
await66 
_uow66 
.66 
SaveChangesAsync66 +
(66+ ,
)66, -
;66- .
}77 
,77 
new77 
BusinessBaseRequest77 &
{77' (

MethodBase77) 3
=774 5

MethodBase776 @
.77@ A
GetCurrentMethod77A Q
(77Q R
)77R S
}77T U
)77U V
;77V W
}88 	
public:: 
Task:: 
<:: 
UserUtil:: 
>:: 
GetByIdAsync:: *
(::* +
int::+ .
id::/ 1
)::1 2
{;; 	
return<<  
CommonOperationAsync<< '
(<<' (
async<<( -
(<<. /
)<</ 0
=><<1 3
await<<4 9
_uow<<: >
.<<> ?
	UserUtils<<? H
.<<H I
GetByIdAsync<<I U
(<<U V
id<<V X
)<<X Y
,<<Y Z
new<<[ ^
BusinessBaseRequest<<_ r
{<<s t

MethodBase<<u 
=
<<Ä Å

MethodBase
<<Ç å
.
<<å ç
GetCurrentMethod
<<ç ù
(
<<ù û
)
<<û ü
}
<<† °
,
<<° ¢
BusinessUtilMethod== "
.==" #
CheckRecordIsExist==# 5
,==5 6
GetType==7 >
(==> ?
)==? @
.==@ A
Name==A E
)==E F
;==F G
}>> 	
public@@ 
Task@@ 
<@@ 
UserUtil@@ 
>@@ 
GetByUserIdAsync@@ .
(@@. /
int@@/ 2
userId@@3 9
)@@9 :
{AA 	
returnBB  
CommonOperationAsyncBB '
(BB' (
asyncBB( -
(BB. /
)BB/ 0
=>BB1 3
awaitBB4 9
_uowBB: >
.BB> ?
	UserUtilsBB? H
.BBH I
GetByUserIdAsyncBBI Y
(BBY Z
userIdBBZ `
)BB` a
,BBa b
newBBc f
BusinessBaseRequestBBg z
{BB{ |

MethodBase	BB} á
=
BBà â

MethodBase
BBä î
.
BBî ï
GetCurrentMethod
BBï •
(
BB• ¶
)
BB¶ ß
}
BB® ©
,
BB© ™
BusinessUtilMethodCC "
.CC" #
CheckRecordIsExistCC# 5
,CC5 6
GetTypeCC7 >
(CC> ?
)CC? @
.CC@ A
NameCCA E
)CCE F
;CCF G
}DD 	
}EE 
}FF Ú
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Constants\AuthorizationConstants.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
	Constants4 =
{ 
public 

static 
class "
AuthorizationConstants .
{ 
public 
const 
string 
Name  
=! "
$str# )
;) *
public 
const 
string 
CustomClaim '
=( )
$str* 7
;7 8
public 
const 
string !
ClientApplicationCode 1
=2 3
$str4 K
;K L
public 
const 
string !
ClientApplicationName 1
=2 3
$str4 K
;K L
public		 
const		 
string		 !
ClientApplicationPass		 1
=		2 3
$str		4 O
;		O P
public

 
const

 
string

 
RoleId

 "
=

# $
$str

% -
;

- .
public 
const 
string 
UserId "
=# $
$str% -
;- .
public 
const 
string 
ClaimId #
=$ %
$str& /
;/ 0
public 
const 
string 
Entity "
=# $
$str% -
;- .
public 
const 
string 
RoleName $
=% &
$str' 1
;1 2
public 
const 
string 
Description '
=( )
$str* 7
;7 8
public 
const 
string 
UserName $
=% &
$str' 1
;1 2
public 
const 
string 
Pass  
=! "
$str# -
;- .
public 
const 
string 
Email !
=" #
$str$ +
;+ ,
public 
const 
string 
EmailConfirmCode ,
=- .
$str/ A
;A B
} 
} —
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Constants\AuthorizationUtilConstants.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
	Constants4 =
{ 
public 

static 
class &
AuthorizationUtilConstants 2
{ 
public 
static 
readonly 
int "$
IterationCountForHashing# ;
=< =
Convert		 
.		 
ToInt32		 
(		 
ConfigHelper		 (
.		( )!
GetConfigurationValue		) >
(		> ?
$str		? e
)		e f
??		g i
$str		j n
)		n o
;		o p
}

 
} ˘
qC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Contracts\ApiRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
	Contracts4 =
{ 
public 

class 

ApiRequest 
: 
IApiRequest )
{ 
public 

ApiRequest 
( 
User 
user #
,# $
ClientApplication% 6
clientApplication7 H
)H I
{		 	
User

 
=

 
user

 
;

 
ClientApplication 
= 
clientApplication  1
;1 2
} 	
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
public 
ClientApplication  
ClientApplication! 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} ∏
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Contracts\IApiRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
	Contracts4 =
{ 
public 

	interface 
IApiRequest  
{ 
User 
User 
{ 
get 
; 
set 
; 
} 
ClientApplication 
ClientApplication +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
}		 
}

 Ï:
|C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseClaimController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class 
BaseClaimController $
:% &4
(BaseControllerWithAuthorizationAndUpdate' O
<O P
ClaimP U
,U V
ClaimRequestW c
,c d
ClaimRequeste q
,q r
ClaimResponse	s Ä
,
Ä Å
IClaimManager
Ç è
,
è ê
int
ë î
>
î ï
{ 
public 
BaseClaimController "
(" #
IClaimManager# 0
claimManager1 =
,= > 
ILocalizationService? S
localizationServiceT g
,g h
ILoggeri p
<p q 
BaseClaimController	q Ñ
>
Ñ Ö
logger
Ü å
,
å ç
IMapper
é ï
mapper
ñ ú
)
ú ù
: 
base 
( 
claimManager 
,  
localizationService! 4
,4 5
logger6 <
,< =
mapper> D
)D E
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
Claim  
)  !
,! "
Crud# '
.' (
Create( .
). /
]/ 0
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
]9 :
ClaimRequest; G
requestH O
)O P
{   	
return!! 
await!! 

BaseCreate!! #
(!!# $
request!!$ +
)!!+ ,
;!!, -
}"" 	
[$$ 	
Route$$	 
($$ 
$str$$  
)$$  !
]$$! "
[%% 	
HttpPut%%	 
]%% 
[&& 	

Permission&&	 
(&& 
nameof&& 
(&& 
Claim&&  
)&&  !
,&&! "
Crud&&# '
.&&' (
Update&&( .
)&&. /
]&&/ 0
public'' 
async'' 
Task'' 
<'' 
IActionResult'' '
>''' (
Update'') /
(''/ 0
int''0 3
id''4 6
,''6 7
[''8 9
FromBody''9 A
]''A B
ClaimRequest''C O
request''P W
)''W X
{(( 	
return)) 
await)) 

BaseUpdate)) #
())# $
id))$ &
,))& '
request))( /
)))/ 0
;))0 1
}** 	
[,, 	
Route,,	 
(,, 
$str,,  
),,  !
],,! "
[-- 	

HttpDelete--	 
]-- 
[.. 	

Permission..	 
(.. 
nameof.. 
(.. 
Claim..  
)..  !
,..! "
Crud..# '
...' (
Delete..( .
)... /
]../ 0
public// 
async// 
Task// 
<// 
IActionResult// '
>//' (
Delete//) /
(/// 0
int//0 3
id//4 6
)//6 7
{00 	
return11 
await11 

BaseDelete11 #
(11# $
id11$ &
)11& '
;11' (
}22 	
[44 	
Route44	 
(44 
$str44  
)44  !
]44! "
[55 	
HttpGet55	 
]55 
[66 	

Permission66	 
(66 
nameof66 
(66 
Claim66  
)66  !
,66! "
Crud66# '
.66' (
Select66( .
)66. /
]66/ 0
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (
GetById77) 0
(770 1
int771 4
id775 7
)777 8
{88 	
return99 
await99 
BaseGetById99 $
(99$ %
id99% '
)99' (
;99( )
}:: 	
[<< 	
Route<<	 
(<< 
$str<< .
)<<. /
]<</ 0
[== 	
HttpGet==	 
]== 
[>> 	

Permission>>	 
(>> 
nameof>> 
(>> 
Claim>>  
)>>  !
,>>! "
Crud>># '
.>>' (
Select>>( .
)>>. /
]>>/ 0
public?? 
async?? 
Task?? 
<?? 
IActionResult?? '
>??' (
GetByCustomClaim??) 9
(??9 :
string??: @
customClaim??A L
)??L M
{@@ 	
varAA 
resultAA 
=AA 
awaitAA 
ManagerAA &
.AA& '!
GetByCustomClaimAsyncAA' <
(AA< =
customClaimAA= H
)AAH I
;AAI J
returnBB 
OkBB 
(BB 
newBB 
ApiResponseBB %
(BB% &
LocalizationServiceBB& 9
,BB9 :
LoggerBB; A
)BBA B
.BBB C
OkBBC E
(BBE F
MapperBBF L
.BBL M
MapBBM P
<BBP Q
ClaimBBQ V
,BBV W
ClaimResponseBBX e
>BBe f
(BBf g
resultBBg m
)BBm n
)BBn o
)BBo p
;BBp q
}CC 	
[EE 	
RouteEE	 
(EE 
$strEE I
)EEI J
]EEJ K
[FF 	
HttpGetFF	 
]FF 
[GG 	

PermissionGG	 
(GG 
nameofGG 
(GG 
ClaimGG  
)GG  !
,GG! "
CrudGG# '
.GG' (
SelectGG( .
)GG. /
]GG/ 0
publicHH 
asyncHH 
TaskHH 
<HH 
IActionResultHH '
>HH' (
GetAllHH) /
(HH/ 0
intHH0 3
	pageIndexHH4 =
,HH= >
intHH? B
pageSizeHHC K
)HHK L
{II 	
varJJ 
resultJJ 
=JJ 
awaitJJ 
ManagerJJ &
.JJ& '
GetAllAsyncJJ' 2
(JJ2 3
	pageIndexJJ3 <
,JJ< =
pageSizeJJ> F
)JJF G
;JJG H
returnKK 
OkKK 
(KK 
newKK 
ApiResponseKK %
(KK% &
LocalizationServiceKK& 9
,KK9 :
LoggerKK; A
)KKA B
.KKB C
OkKKC E
(KKE F
MapperLL 
.LL 
MapLL 
<LL 
IListLL  
<LL  !
ClaimLL! &
>LL& '
,LL' (
IListLL) .
<LL. /
ClaimResponseLL/ <
>LL< =
>LL= >
(LL> ?
resultLL? E
.LLE F

ResultListLLF P
)LLP Q
,LLQ R
resultMM 
.MM 
CountMM 
)MM 
)MM 
;MM 
}NN 	
}OO 
}PP “A
àC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseClientApplicationController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class +
BaseClientApplicationController 0
: 	+
BaseControllerWithAuthorization
 )
<) *
ClientApplication* ;
,; <$
ClientApplicationRequest= U
,U V%
ClientApplicationResponseW p
,p q&
IClientApplicationManager	r ã
,
ã å
int
ç ê
>
ê ë
{ 
public +
BaseClientApplicationController .
(. /%
IClientApplicationManager/ H$
clientApplicationManagerI a
,a b 
ILocalizationServicec w 
localizationService	x ã
,
ã å
ILogger
ç î
<
î ï-
BaseClientApplicationController
ï ¥
>
¥ µ
logger
∂ º
,
º Ω
IMapper
æ ≈
mapper
∆ Ã
)
Ã Õ
: 
base 
( $
clientApplicationManager +
,+ ,
localizationService- @
,@ A
loggerB H
,H I
mapperJ P
)P Q
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
ClientApplication ,
), -
,- .
Crud/ 3
.3 4
Create4 :
): ;
]; <
public   
async   
Task   
<   
IActionResult   '
>  ' (
Create  ) /
(  / 0
[  0 1
FromBody  1 9
]  9 :$
ClientApplicationRequest  ; S
request  T [
)  [ \
{!! 	
return"" 
await"" 

BaseCreate"" #
(""# $
request""$ +
)""+ ,
;"", -
}## 	
[%% 	
Route%%	 
(%% 
$str%%  
)%%  !
]%%! "
[&& 	

HttpDelete&&	 
]&& 
['' 	

Permission''	 
('' 
nameof'' 
('' 
ClientApplication'' ,
)'', -
,''- .
Crud''/ 3
.''3 4
Delete''4 :
)'': ;
]''; <
public(( 
async(( 
Task(( 
<(( 
IActionResult(( '
>((' (
Delete(() /
(((/ 0
int((0 3
id((4 6
)((6 7
{)) 	
return** 
await** 

BaseDelete** #
(**# $
id**$ &
)**& '
;**' (
}++ 	
[-- 	
Route--	 
(-- 
$str-- 
)-- 
]-- 
[.. 	
HttpGet..	 
].. 
[// 	

Permission//	 
(// 
nameof// 
(// 
ClientApplication// ,
)//, -
,//- .
Crud/// 3
.//3 4
Select//4 :
)//: ;
]//; <
public00 
async00 
Task00 
<00 
IActionResult00 '
>00' (
GetById00) 0
(000 1
int001 4
id005 7
)007 8
{11 	
return22 
await22 
BaseGetById22 $
(22$ %
id22% '
)22' (
;22( )
}33 	
[55 	
Route55	 
(55 
$str55  
)55  !
]55! "
[66 	
HttpPut66	 
]66 
[77 	

Permission77	 
(77 
nameof77 
(77 
ClientApplication77 ,
)77, -
,77- .
Crud77/ 3
.773 4
Update774 :
)77: ;
]77; <
public88 
async88 
Task88 
<88 
IActionResult88 '
>88' ('
UpdateClientApplicationName88) D
(88D E
int88E H
id88I K
,88K L
[88M N
FromBody88N V
]88V W*
ClientApplicationUpdateRequest88X v
request88w ~
)88~ 
{99 	
var:: 
result:: 
=:: 
await:: 
Manager:: &
.::& '
UpdateAsync::' 2
(::2 3
id::3 5
,::5 6
request::7 >
)::> ?
;::? @
return;; 
Ok;; 
(;; 
new;; 
ApiResponse;; %
(;;% &
LocalizationService;;& 9
,;;9 :
Logger;;; A
);;A B
.;;B C
Ok;;C E
(;;E F
Mapper;;F L
.;;L M
Map;;M P
<;;P Q
ClientApplication;;Q b
,;;b c%
ClientApplicationResponse;;d }
>;;} ~
(;;~ 
result	;; Ö
)
;;Ö Ü
)
;;Ü á
)
;;á à
;
;;à â
}<< 	
[>> 	
Route>>	 
(>> 
$str>> :
)>>: ;
]>>; <
[?? 	
HttpPut??	 
]?? 
[@@ 	
AllowAnonymous@@	 
]@@ 
[AA 	

PermissionAA	 
(AA 
nameofAA 
(AA 
ClientApplicationAA ,
)AA, -
,AA- .
CrudAA/ 3
.AA3 4
UpdateAA4 :
)AA: ;
]AA; <
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (+
UpdateClientApplicationPasswordBB) H
(BBH I
intBBI L
idBBM O
,BBO P
[BBQ R
FromBodyBBR Z
]BBZ [
stringBB\ b%
clientApplicationPasswordBBc |
)BB| }
{CC 	
varDD 
resultDD 
=DD 
awaitDD 
ManagerDD &
.DD& '0
$UpdateClientApplicationPasswordAsyncDD' K
(DDK L
idDDL N
,DDN O%
clientApplicationPasswordDDP i
)DDi j
;DDj k
returnEE 
OkEE 
(EE 
newEE 
ApiResponseEE %
(EE% &
LocalizationServiceEE& 9
,EE9 :
LoggerEE; A
)EEA B
.EEB C
OkEEC E
(EEE F
MapperEEF L
.EEL M
MapEEM P
<EEP Q
ClientApplicationEEQ b
,EEb c%
ClientApplicationResponseEEd }
>EE} ~
(EE~ 
result	EE Ö
)
EEÖ Ü
)
EEÜ á
)
EEá à
;
EEà â
}FF 	
[HH 	
RouteHH	 
(HH 
$strHH B
)HHB C
]HHC D
[II 	
HttpGetII	 
]II 
[JJ 	

PermissionJJ	 
(JJ 
nameofJJ 
(JJ 
ClientApplicationJJ ,
)JJ, -
,JJ- .
CrudJJ/ 3
.JJ3 4
SelectJJ4 :
)JJ: ;
]JJ; <
publicKK 
asyncKK 
TaskKK 
<KK 
IActionResultKK '
>KK' (&
GetByClientApplicationCodeKK) C
(KKC D
stringKKD J!
clientapplicationcodeKKK `
)KK` a
{LL 	
varMM 
resultMM 
=MM 
awaitMM 
ManagerMM &
.MM& '+
GetByClientApplicationCodeAsyncMM' F
(MMF G!
clientapplicationcodeMMG \
)MM\ ]
;MM] ^
returnNN 
OkNN 
(NN 
newNN 
ApiResponseNN %
(NN% &
LocalizationServiceNN& 9
,NN9 :
LoggerNN; A
)NNA B
.NNB C
OkNNC E
(NNE F
MapperNNF L
.NNL M
MapNNM P
<NNP Q
ClientApplicationNNQ b
,NNb c%
ClientApplicationResponseNNd }
>NN} ~
(NN~ 
result	NN Ö
)
NNÖ Ü
)
NNÜ á
)
NNá à
;
NNà â
}OO 	
}PP 
}QQ ﬂ%
àC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseControllerWithAuthorization.cs
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
% &
Authorization

& 3
.

3 4
Controllers

4 ?
{ 
public 

abstract 
class +
BaseControllerWithAuthorization 9
<9 :
TEntity: A
,A B
TCreateRequestC Q
,Q R
	TResponseS \
,\ ]
TManager^ f
,f g
TKeyh l
>l m
:n o

Controllerp z
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
	protected +
BaseControllerWithAuthorization 1
(1 2
TManager2 :
manager; B
,B C 
ILocalizationServiceD X
localizationServiceY l
,l m
ILoggern u
<u v

Controller	v Ä
>
Ä Å
logger
Ç à
,
à â
IMapper
ä ë
mapper
í ò
)
ò ô
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
} 	
	protected 
async 
Task 
< 
IActionResult *
>* +

BaseCreate, 6
(6 7
[7 8
FromBody8 @
]@ A
TCreateRequestB P
requestQ X
)X Y
{ 	
var 
result 
= 
await 
Manager &
.& '
CreateAsync' 2
(2 3
request3 :
): ;
;; <
return   
Ok   
(   
new   
ApiResponse   %
(  % &
LocalizationService  & 9
,  9 :
Logger  ; A
)  A B
.  B C
Ok  C E
(  E F
Mapper  F L
.  L M
Map  M P
<  P Q
TEntity  Q X
,  X Y
	TResponse  Z c
>  c d
(  d e
result  e k
)  k l
)  l m
)  m n
;  n o
}!! 	
	protected## 
async## 
Task## 
<## 
IActionResult## *
>##* +

BaseDelete##, 6
(##6 7
TKey##7 ;
id##< >
)##> ?
{$$ 	
await%% 
Manager%% 
.%% 
DeleteAsync%% %
(%%% &
id%%& (
)%%( )
;%%) *
return&& 
Ok&& 
(&& 
new&& 
ApiResponse&& %
(&&% &
LocalizationService&&& 9
,&&9 :
Logger&&; A
)&&A B
.&&B C
Ok&&C E
(&&E F
true&&F J
)&&J K
)&&K L
;&&L M
}'' 	
	protected)) 
async)) 
Task)) 
<)) 
IActionResult)) *
>))* +
BaseGetById)), 7
())7 8
TKey))8 <
id))= ?
)))? @
{** 	
var++ 
result++ 
=++ 
await++ 
Manager++ &
.++& '
GetByIdAsync++' 3
(++3 4
id++4 6
)++6 7
;++7 8
return,, 
Ok,, 
(,, 
new,, 
ApiResponse,, %
(,,% &
LocalizationService,,& 9
,,,9 :
Logger,,; A
),,A B
.,,B C
Ok,,C E
(,,E F
Mapper,,F L
.,,L M
Map,,M P
<,,P Q
TEntity,,Q X
,,,X Y
	TResponse,,Z c
>,,c d
(,,d e
result,,e k
),,k l
),,l m
),,m n
;,,n o
}-- 	
}.. 
}// ê
ëC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseControllerWithAuthorizationAndUpdate.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
public 

abstract 
class 4
(BaseControllerWithAuthorizationAndUpdate B
<B C
TEntityC J
,J K
TCreateRequestL Z
,Z [
TUpdateRequest\ j
,j k
	TResponsel u
,u v
TManagerw 
,	 Ä
TKey
Å Ö
>
Ö Ü
: 	+
BaseControllerWithAuthorization
 )
<) *
TEntity* 1
,1 2
TCreateRequest3 A
,A B
	TResponseC L
,L M
TManagerN V
,V W
TKeyX \
>\ ]
where 
TEntity 
: 
	BaseModel !
<! "
TKey" &
>& '
where 
TManager 
: 
IBusinessManager )
<) *
TEntity* 1
,1 2
TCreateRequest3 A
,A B
TKeyC G
>G H
,H I"
IBusinessManagerUpdateJ `
<` a
TEntitya h
,h i
TUpdateRequestj x
,x y
TKeyz ~
>~ 
{ 
	protected 4
(BaseControllerWithAuthorizationAndUpdate :
(: ;
TManager; C
managerD K
,K L 
ILocalizationServiceM a
localizationServiceb u
,u v
ILoggerw ~
<~ 

Controller	 â
>
â ä
logger
ã ë
,
ë í
IMapper
ì ö
mapper
õ °
)
° ¢
: 	
base
 
( 
manager 
, 
localizationService +
,+ ,
logger- 3
,3 4
mapper5 ;
); <
{ 	
} 	
	protected 
async 
Task 
< 
IActionResult *
>* +

BaseUpdate, 6
(6 7
TKey7 ;
id< >
,> ?
[@ A
FromBodyA I
]I J
TUpdateRequestK Y
requestZ a
)a b
{ 	
var 
result 
= 
await 
Manager &
.& '
UpdateAsync' 2
(2 3
id3 5
,5 6
request7 >
)> ?
;? @
return 
Ok 
( 
new 
ApiResponse %
(% &
LocalizationService& 9
,9 :
Logger; A
)A B
.B C
OkC E
(E F
MapperF L
.L M
MapM P
<P Q
TEntityQ X
,X Y
	TResponseZ c
>c d
(d e
resulte k
)k l
)l m
)m n
;n o
}   	
}!! 
}"" ç5
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseRoleClaimController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class #
BaseRoleClaimController (
:) *+
BaseControllerWithAuthorization+ J
<J K
	RoleClaimK T
,T U
RoleClaimRequestV f
,f g
RoleClaimResponseh y
,y z
IRoleClaimManager	{ å
,
å ç
int
é ë
>
ë í
{ 
public #
BaseRoleClaimController &
(& '
IRoleClaimManager' 8
roleClaimManager9 I
,I J 
ILocalizationServiceK _
localizationService` s
,s t
ILoggeru |
<| }$
BaseRoleClaimController	} î
>
î ï
logger
ñ ú
,
ú ù
IMapper
û •
mapper
¶ ¨
)
¨ ≠
: 
base 
( 
roleClaimManager #
,# $
localizationService% 8
,8 9
logger: @
,@ A
mapperB H
)H I
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
	RoleClaim $
)$ %
,% &
Crud' +
.+ ,
Create, 2
)2 3
]3 4
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
]9 :
RoleClaimRequest; K
requestL S
)S T
{   	
return!! 
await!! 

BaseCreate!! #
(!!# $
request!!$ +
)!!+ ,
;!!, -
}"" 	
[$$ 	
Route$$	 
($$ 
$str$$  
)$$  !
]$$! "
[%% 	

HttpDelete%%	 
]%% 
[&& 	

Permission&&	 
(&& 
nameof&& 
(&& 
	RoleClaim&& $
)&&$ %
,&&% &
Crud&&' +
.&&+ ,
Delete&&, 2
)&&2 3
]&&3 4
public'' 
async'' 
Task'' 
<'' 
IActionResult'' '
>''' (
Delete'') /
(''/ 0
int''0 3
id''4 6
)''6 7
{(( 	
return)) 
await)) 

BaseDelete)) #
())# $
id))$ &
)))& '
;))' (
}** 	
[,, 	
Route,,	 
(,, 
$str,, 
),, 
],, 
[-- 	
HttpGet--	 
]-- 
[.. 	

Permission..	 
(.. 
nameof.. 
(.. 
	RoleClaim.. $
)..$ %
,..% &
Crud..' +
...+ ,
Select.., 2
)..2 3
]..3 4
public// 
async// 
Task// 
<// 
IActionResult// '
>//' (
GetById//) 0
(//0 1
int//1 4
id//5 7
)//7 8
{00 	
return11 
await11 
BaseGetById11 $
(11$ %
id11% '
)11' (
;11( )
}22 	
[44 	
Route44	 
(44 
$str44 +
)44+ ,
]44, -
[55 	
HttpGet55	 
]55 
[66 	

Permission66	 
(66 
nameof66 
(66 
	RoleClaim66 $
)66$ %
,66% &
Crud66' +
.66+ ,
Select66, 2
)662 3
]663 4
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (
GetRolesByClaimId77) :
(77: ;
int77; >
claimId77? F
)77F G
{88 	
var99 
result99 
=99 
await99 
Manager99 &
.99& '"
GetRolesByClaimIdAsync99' =
(99= >
claimId99> E
)99E F
;99F G
return:: 
Ok:: 
(:: 
new:: 
ApiResponse:: %
(::% &
LocalizationService::& 9
,::9 :
Logger::; A
)::A B
.::B C
Ok::C E
(::E F
Mapper;; 
.;; 
Map;; 
<;; 
IList;;  
<;;  !
Role;;! %
>;;% &
,;;& '
IList;;( -
<;;- .
RoleResponse;;. :
>;;: ;
>;;; <
(;;< =
result;;= C
.;;C D

ResultList;;D N
);;N O
,;;O P
result<< 
.<< 
Count<< 
)<< 
)<< 
;<< 
}== 	
[?? 	
Route??	 
(?? 
$str?? *
)??* +
]??+ ,
[@@ 	
HttpGet@@	 
]@@ 
[AA 	

PermissionAA	 
(AA 
nameofAA 
(AA 
	RoleClaimAA $
)AA$ %
,AA% &
CrudAA' +
.AA+ ,
SelectAA, 2
)AA2 3
]AA3 4
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
GetClaimsByRoleIdBB) :
(BB: ;
intBB; >
roleIdBB? E
)BBE F
{CC 	
varDD 
resultDD 
=DD 
awaitDD 
ManagerDD &
.DD& '"
GetClaimsByRoleIdAsyncDD' =
(DD= >
roleIdDD> D
)DDD E
;DDE F
returnEE 
OkEE 
(EE 
newEE 
ApiResponseEE %
(EE% &
LocalizationServiceEE& 9
,EE9 :
LoggerEE; A
)EEA B
.EEB C
OkEEC E
(EEE F
MapperFF 
.FF 
MapFF 
<FF 
IListFF  
<FF  !
ClaimFF! &
>FF& '
,FF' (
IListFF) .
<FF. /
ClaimResponseFF/ <
>FF< =
>FF= >
(FF> ?
resultFF? E
.FFE F

ResultListFFF P
)FFP Q
,FFQ R
resultGG 
.GG 
CountGG 
)GG 
)GG 
;GG 
}HH 	
}II 
}JJ ≤9
{C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseRoleController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class 
BaseRoleController #
:$ %4
(BaseControllerWithAuthorizationAndUpdate& N
<N O
RoleO S
,S T
RoleRequestU `
,` a
RoleRequestb m
,m n
RoleResponseo {
,{ |
IRoleManager	} â
,
â ä
int
ã é
>
é è
{ 
public 
BaseRoleController !
(! "
IRoleManager" .
roleManager/ :
,: ; 
ILocalizationService< P
localizationServiceQ d
,d e
ILoggerf m
<m n
BaseRoleController	n Ä
>
Ä Å
logger
Ç à
,
à â
IMapper
ä ë
mapper
í ò
)
ò ô
: 
base 
( 
roleManager 
, 
localizationService  3
,3 4
logger5 ;
,; <
mapper= C
)C D
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
Role 
)  
,  !
Crud" &
.& '
Create' -
)- .
]. /
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :
RoleRequest; F
requestG N
)N O
{ 	
return 
await 

BaseCreate #
(# $
request$ +
)+ ,
;, -
}   	
["" 	
Route""	 
("" 
$str"" 
)"" 
]"" 
[## 	
HttpPut##	 
]## 
[$$ 	

Permission$$	 
($$ 
nameof$$ 
($$ 
Role$$ 
)$$  
,$$  !
Crud$$" &
.$$& '
Update$$' -
)$$- .
]$$. /
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
Update%%) /
(%%/ 0
int%%0 3
id%%4 6
,%%6 7
[%%8 9
FromBody%%9 A
]%%A B
RoleRequest%%C N
request%%O V
)%%V W
{&& 	
return'' 
await'' 

BaseUpdate'' #
(''# $
id''$ &
,''& '
request''( /
)''/ 0
;''0 1
}(( 	
[** 	
Route**	 
(** 
$str**  
)**  !
]**! "
[++ 	

HttpDelete++	 
]++ 
[,, 	

Permission,,	 
(,, 
nameof,, 
(,, 
Role,, 
),,  
,,,  !
Crud,," &
.,,& '
Delete,,' -
),,- .
],,. /
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
Delete--) /
(--/ 0
int--0 3
id--4 6
)--6 7
{.. 	
return// 
await// 

BaseDelete// #
(//# $
id//$ &
)//& '
;//' (
}00 	
[22 	
Route22	 
(22 
$str22 
)22 
]22 
[33 	
HttpGet33	 
]33 
[44 	

Permission44	 
(44 
nameof44 
(44 
Role44 
)44  
,44  !
Crud44" &
.44& '
Select44' -
)44- .
]44. /
public55 
async55 
Task55 
<55 
IActionResult55 '
>55' (
GetById55) 0
(550 1
int551 4
id555 7
)557 8
{66 	
return77 
await77 
BaseGetById77 $
(77$ %
id77% '
)77' (
;77( )
}88 	
[:: 	
Route::	 
(:: 
$str:: (
)::( )
]::) *
[;; 	
HttpGet;;	 
];; 
[<< 	

Permission<<	 
(<< 
nameof<< 
(<< 
Role<< 
)<<  
,<<  !
Crud<<" &
.<<& '
Select<<' -
)<<- .
]<<. /
public== 
async== 
Task== 
<== 
IActionResult== '
>==' (
GetByRoleName==) 6
(==6 7
string==7 =
roleName==> F
)==F G
{>> 	
var?? 
result?? 
=?? 
await?? 
Manager?? &
.??& '
GetByNameAsync??' 5
(??5 6
roleName??6 >
)??> ?
;??? @
return@@ 
Ok@@ 
(@@ 
new@@ 
ApiResponse@@ %
(@@% &
LocalizationService@@& 9
,@@9 :
Logger@@; A
)@@A B
.@@B C
Ok@@C E
(@@E F
Mapper@@F L
.@@L M
Map@@M P
<@@P Q
Role@@Q U
,@@U V
RoleResponse@@W c
>@@c d
(@@d e
result@@e k
)@@k l
)@@l m
)@@m n
;@@n o
}AA 	
[CC 	
RouteCC	 
(CC 
$strCC 
)CC 
]CC 
[DD 	
HttpGetDD	 
]DD 
[EE 	

PermissionEE	 
(EE 
nameofEE 
(EE 
RoleEE 
)EE  
,EE  !
CrudEE" &
.EE& '
SelectEE' -
)EE- .
]EE. /
publicFF 
asyncFF 
TaskFF 
<FF 
IActionResultFF '
>FF' (
GetAllFF) /
(FF/ 0
)FF0 1
{GG 	
varHH 
resultHH 
=HH 
awaitHH 
ManagerHH &
.HH& '
GetAllAsyncHH' 2
(HH2 3
)HH3 4
;HH4 5
returnII 
OkII 
(II 
newII 
ApiResponseII %
(II% &
LocalizationServiceII& 9
,II9 :
LoggerII; A
)IIA B
.IIB C
OkIIC E
(IIE F
MapperJJ 
.JJ 
MapJJ 
<JJ 
IEnumerableJJ &
<JJ& '
RoleJJ' +
>JJ+ ,
,JJ, -
IEnumerableJJ. 9
<JJ9 :
RoleResponseJJ: F
>JJF G
>JJG H
(JJH I
resultJJI O
.JJO P

ResultListJJP Z
)JJZ [
,JJ[ \
resultKK 
.KK 
CountKK 
)KK 
)KK 
;KK 
}LL 	
}MM 
}NN ‰=
ÜC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseRoleEntityClaimController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class )
BaseRoleEntityClaimController .
: 	4
(BaseControllerWithAuthorizationAndUpdate
 2
<2 3
RoleEntityClaim3 B
,B C"
RoleEntityClaimRequestD Z
,Z [
EntityClaimRequest\ n
,n o$
RoleEntityClaimResponse	p á
,
á à%
IRoleEntityClaimManager
â †
,
† °
int
¢ •
>
• ¶
{ 
public )
BaseRoleEntityClaimController ,
(, -#
IRoleEntityClaimManager- D"
roleEntityClaimManagerE [
,[ \ 
ILocalizationService] q 
localizationService	r Ö
,
Ö Ü
ILogger
á é
<
é è+
BaseRoleEntityClaimController
è ¨
>
¨ ≠
logger
Æ ¥
,
¥ µ
IMapper
∂ Ω
mapper
æ ƒ
)
ƒ ≈
: 
base 
( "
roleEntityClaimManager )
,) *
localizationService+ >
,> ?
logger@ F
,F G
mapperH N
)N O
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
RoleEntityClaim *
)* +
,+ ,
Crud- 1
.1 2
Create2 8
)8 9
]9 :
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :"
RoleEntityClaimRequest; Q
requestR Y
)Y Z
{ 	
return   
await   

BaseCreate   #
(  # $
request  $ +
)  + ,
;  , -
}!! 	
[## 	
Route##	 
(## 
$str## 
)## 
]## 
[$$ 	
HttpPut$$	 
]$$ 
[%% 	

Permission%%	 
(%% 
nameof%% 
(%% 
RoleEntityClaim%% *
)%%* +
,%%+ ,
Crud%%- 1
.%%1 2
Update%%2 8
)%%8 9
]%%9 :
public&& 
async&& 
Task&& 
<&& 
IActionResult&& '
>&&' (
Update&&) /
(&&/ 0
int&&0 3
id&&4 6
,&&6 7
[&&8 9
FromBody&&9 A
]&&A B
EntityClaimRequest&&C U
request&&V ]
)&&] ^
{'' 	
return(( 
await(( 

BaseUpdate(( #
(((# $
id(($ &
,((& '
request((( /
)((/ 0
;((0 1
})) 	
[++ 	
Route++	 
(++ 
$str++  
)++  !
]++! "
[,, 	

HttpDelete,,	 
],, 
[-- 	

Permission--	 
(-- 
nameof-- 
(-- 
RoleEntityClaim-- *
)--* +
,--+ ,
Crud--- 1
.--1 2
Delete--2 8
)--8 9
]--9 :
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
Delete..) /
(../ 0
int..0 3
id..4 6
)..6 7
{// 	
return00 
await00 

BaseDelete00 #
(00# $
id00$ &
)00& '
;00' (
}11 	
[33 	
Route33	 
(33 
$str33 
)33 
]33 
[44 	
HttpGet44	 
]44 
[55 	

Permission55	 
(55 
nameof55 
(55 
RoleEntityClaim55 *
)55* +
,55+ ,
Crud55- 1
.551 2
Select552 8
)558 9
]559 :
public66 
async66 
Task66 
<66 
IActionResult66 '
>66' (
GetById66) 0
(660 1
int661 4
id665 7
)667 8
{77 	
return88 
await88 
BaseGetById88 $
(88$ %
id88% '
)88' (
;88( )
}99 	
[;; 	
Route;;	 
(;; 
$str;; '
);;' (
];;( )
[<< 	
HttpGet<<	 
]<< 
[== 	

Permission==	 
(== 
nameof== 
(== 
RoleEntityClaim== *
)==* +
,==+ ,
Crud==- 1
.==1 2
Select==2 8
)==8 9
]==9 :
public>> 
async>> 
Task>> 
<>> 
IActionResult>> '
>>>' (
GetAllByEntity>>) 7
(>>7 8
string>>8 >
entity>>? E
)>>E F
{?? 	
var@@ 
result@@ 
=@@ 
await@@ 
Manager@@ &
.@@& '
GetAllByEntityAsync@@' :
(@@: ;
entity@@; A
)@@A B
;@@B C
returnAA 
OkAA 
(AA 
newAA 
ApiResponseAA %
(AA% &
LocalizationServiceAA& 9
,AA9 :
LoggerAA; A
)AAA B
.AAB C
OkAAC E
(AAE F
MapperBB 
.BB 
MapBB 
<BB 
IEnumerableBB &
<BB& '
RoleEntityClaimBB' 6
>BB6 7
,BB7 8
IEnumerableBB9 D
<BBD E#
RoleEntityClaimResponseBBE \
>BB\ ]
>BB] ^
(BB^ _
resultBB_ e
.BBe f

ResultListBBf p
)BBp q
,BBq r
resultCC 
.CC 
CountCC 
)CC 
)CC 
;CC 
}DD 	
[FF 	
RouteFF	 
(FF 
$strFF +
)FF+ ,
]FF, -
[GG 	
HttpGetGG	 
]GG 
[HH 	

PermissionHH	 
(HH 
nameofHH 
(HH 
RoleEntityClaimHH *
)HH* +
,HH+ ,
CrudHH- 1
.HH1 2
SelectHH2 8
)HH8 9
]HH9 :
publicII 
asyncII 
TaskII 
<II 
IActionResultII '
>II' (
GetAllByRoleIdII) 7
(II7 8
intII8 ;
roleIdII< B
)IIB C
{JJ 	
varKK 
resultKK 
=KK 
awaitKK 
ManagerKK &
.KK& '
GetAllByRoleIdAsyncKK' :
(KK: ;
roleIdKK; A
)KKA B
;KKB C
returnLL 
OkLL 
(LL 
newLL 
ApiResponseLL %
(LL% &
LocalizationServiceLL& 9
,LL9 :
LoggerLL; A
)LLA B
.LLB C
OkLLC E
(LLE F
MapperMM 
.MM 
MapMM 
<MM 
IEnumerableMM &
<MM& '
RoleEntityClaimMM' 6
>MM6 7
,MM7 8
IEnumerableMM9 D
<MMD E#
RoleEntityClaimResponseMME \
>MM\ ]
>MM] ^
(MM^ _
resultMM_ e
.MMe f

ResultListMMf p
)MMp q
,MMq r
resultNN 
.NN 
CountNN 
)NN 
)NN 
;NN 
}OO 	
}PP 
}QQ É2
|C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseTokenController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class 
BaseTokenController $
:% &

Controller' 1
{ 
private 
readonly %
IClientApplicationManager 2%
_clientApplicationManager3 L
;L M
private 
readonly 
IUserManager %
_userManager& 2
;2 3
private 
readonly  
ILocalizationService - 
_localizationService. B
;B C
private 
readonly 
ILogger  
<  !
BaseTokenController! 4
>4 5
_logger6 =
;= >
private 
readonly 
IToken 
_token  &
;& '
public   
BaseTokenController   "
(  " #%
IClientApplicationManager  # <$
clientApplicationManager  = U
,  U V
IUserManager  W c
userManager  d o
,  o p!
ILocalizationService	  q Ö!
localizationService
  Ü ô
,
  ô ö
ILogger
  õ ¢
<
  ¢ £!
BaseTokenController
  £ ∂
>
  ∂ ∑
logger
  ∏ æ
,
  æ ø
IToken
  ¿ ∆
token
  « Ã
)
  Ã Õ
{!! 	%
_clientApplicationManager"" %
=""& '$
clientApplicationManager""( @
;""@ A
_userManager## 
=## 
userManager## &
;##& ' 
_localizationService$$  
=$$! "
localizationService$$# 6
;$$6 7
_logger%% 
=%% 
logger%% 
;%% 
_token&& 
=&& 
token&& 
;&& 
}'' 	
[)) 	
AllowAnonymous))	 
])) 
[** 	
HttpPost**	 
]** 
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
Login++) .
(++. /
[++/ 0
FromBody++0 8
]++8 9
Login++: ?
login++@ E
)++E F
{,, 	
if-- 
(-- 
!-- 

ModelState-- 
.-- 
IsValid-- #
)--# $
throw.. 
new.. 
ArgumentException.. +
(..+ ,

ModelState.., 6
...6 7
ModelStateToString..7 I
(..I J 
_localizationService..J ^
)..^ _
).._ `
;..` a
var00 
clientApplication00 !
=00" #
await11 %
_clientApplicationManager11 /
.11/ 0

LoginAsync110 :
(11: ;
login11; @
.11@ A!
ClientApplicationCode11A V
,11V W
login11X ]
.11] ^%
ClientApplicationPassword11^ w
)11w x
;11x y
var33 
user33 
=33 
await33 
_userManager33 )
.33) *

LoginAsync33* 4
(334 5
login335 :
.33: ;
UserName33; C
,33C D
login33E J
.33J K
UserPassword33K W
)33W X
;33X Y
var55 

apiRequest55 
=55 
new55  

ApiRequest55! +
(55+ ,
user55, 0
,550 1
clientApplication552 C
)55C D
;55D E
var77 
claims77 
=77 
new77 
List77 !
<77! "
Claim77" '
>77' (
{88 
new99 
Claim99 
(99 
typeof99  
(99  !
IApiRequest99! ,
)99, -
.99- .
Name99. 2
,992 3
JsonConvert994 ?
.99? @
SerializeObject99@ O
(99O P

apiRequest99P Z
)99Z [
)99[ \
,99\ ]
new:: 
Claim:: 
(:: #
JwtRegisteredClaimNames:: 1
.::1 2
Jti::2 5
,::5 6
Guid::7 ;
.::; <
NewGuid::< C
(::C D
)::D E
.::E F
ToString::F N
(::N O
)::O P
)::P Q
,::Q R
};; 
;;; 
var== 
key== 
=== 
_token== 
.== 
Key==  
;==  !
var>> 
issuer>> 
=>> 
_token>> 
.>>  
Issuer>>  &
;>>& '
var?? 
audience?? 
=?? 
_token?? !
.??! "
Audience??" *
;??* +
var@@ 
expireInMinutes@@ 
=@@  !
_token@@" (
.@@( )
ExpireInMinutes@@) 8
;@@8 9
varAA 
tokenAA 
=AA 

JwtManagerAA "
.AA" #
GenerateTokenAA# 0
(AA0 1
claimsAA1 7
,AA7 8
keyAA9 <
,AA< =
issuerAA> D
,AAD E
audienceAAF N
,AAN O
outAAP S
varAAT W
expireDateTimeAAX f
,AAf g
expireInMinutesAAh w
)AAw x
;AAx y
varCC 
tokenResponseCC 
=CC 
newCC  #
TokenResponseCC$ 1
{DD 
TokenEE 
=EE 
tokenEE 
,EE 
ExpireInMinutesFF 
=FF  !
expireInMinutesFF" 1
,FF1 2
RequestUtcDateTimeGG "
=GG# $
DateTimeGG% -
.GG- .
UtcNowGG. 4
,GG4 5
ExpireUtcDateTimeHH !
=HH" #
expireDateTimeHH$ 2
,HH2 3
}II 
;II 
returnKK 
OkKK 
(KK 
newKK 
ApiResponseKK %
(KK% & 
_localizationServiceKK& :
,KK: ;
_loggerKK< C
)KKC D
.KKD E
OkKKE G
(KKG H
tokenResponseKKH U
)KKU V
)KKV W
;KKW X
}LL 	
}MM 
}NN •5
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseUserClaimController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class #
BaseUserClaimController (
:) *+
BaseControllerWithAuthorization+ J
<J K
	UserClaimK T
,T U
UserClaimRequestV f
,f g
UserClaimResponseh y
,y z
IUserClaimManager	{ å
,
å ç
int
é ë
>
ë í
{ 
public #
BaseUserClaimController &
(& '
IUserClaimManager' 8
userClaimManager9 I
,I J 
ILocalizationServiceK _
localizationService` s
,s t
ILoggeru |
<| }$
BaseUserClaimController	} î
>
î ï
logger
ñ ú
,
ú ù
IMapper
û •
mapper
¶ ¨
)
¨ ≠
: 
base 
( 
userClaimManager #
,# $
localizationService% 8
,8 9
logger: @
,@ A
mapperB H
)H I
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
	UserClaim $
)$ %
,% &
Crud' +
.+ ,
Create, 2
)2 3
]3 4
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :
UserClaimRequest; K
requestL S
)S T
{ 	
return 
await 

BaseCreate #
(# $
request$ +
)+ ,
;, -
}   	
["" 	
Route""	 
("" 
$str""  
)""  !
]""! "
[## 	

HttpDelete##	 
]## 
[$$ 	

Permission$$	 
($$ 
nameof$$ 
($$ 
	UserClaim$$ $
)$$$ %
,$$% &
Crud$$' +
.$$+ ,
Delete$$, 2
)$$2 3
]$$3 4
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
Delete%%) /
(%%/ 0
int%%0 3
id%%4 6
)%%6 7
{&& 	
return'' 
await'' 

BaseDelete'' #
(''# $
id''$ &
)''& '
;''' (
}(( 	
[** 	
Route**	 
(** 
$str** 
)** 
]** 
[++ 	
HttpGet++	 
]++ 
[,, 	

Permission,,	 
(,, 
nameof,, 
(,, 
	UserClaim,, $
),,$ %
,,,% &
Crud,,' +
.,,+ ,
Select,,, 2
),,2 3
],,3 4
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
GetById--) 0
(--0 1
int--1 4
id--5 7
)--7 8
{.. 	
return// 
await// 
BaseGetById// $
(//$ %
id//% '
)//' (
;//( )
}00 	
[22 	
Route22	 
(22 
$str22 +
)22+ ,
]22, -
[33 	
HttpGet33	 
]33 
[44 	

Permission44	 
(44 
nameof44 
(44 
	UserClaim44 $
)44$ %
,44% &
Crud44' +
.44+ ,
Select44, 2
)442 3
]443 4
public55 
async55 
Task55 
<55 
IActionResult55 '
>55' (
GetUsersByClaimId55) :
(55: ;
int55; >
claimId55? F
)55F G
{66 	
var77 
result77 
=77 
await77 
Manager77 &
.77& '"
GetUsersByClaimIdAsync77' =
(77= >
claimId77> E
)77E F
;77F G
return88 
Ok88 
(88 
new88 
ApiResponse88 %
(88% &
LocalizationService88& 9
,889 :
Logger88; A
)88A B
.88B C
Ok88C E
(88E F
Mapper99 
.99 
Map99 
<99 
IEnumerable99 &
<99& '
User99' +
>99+ ,
,99, -
IEnumerable99. 9
<999 :
UserResponse99: F
>99F G
>99G H
(99H I
result99I O
.99O P

ResultList99P Z
)99Z [
,99[ \
result:: 
.:: 
Count:: 
):: 
):: 
;:: 
};; 	
[== 	
Route==	 
(== 
$str== *
)==* +
]==+ ,
[>> 	
HttpGet>>	 
]>> 
[?? 	

Permission??	 
(?? 
nameof?? 
(?? 
	UserClaim?? $
)??$ %
,??% &
Crud??' +
.??+ ,
Select??, 2
)??2 3
]??3 4
public@@ 
async@@ 
Task@@ 
<@@ 
IActionResult@@ '
>@@' (
GetClaimsByUserId@@) :
(@@: ;
int@@; >
userId@@? E
)@@E F
{AA 	
varBB 
resultBB 
=BB 
awaitBB 
ManagerBB &
.BB& '"
GetClaimsByUserIdAsyncBB' =
(BB= >
userIdBB> D
)BBD E
;BBE F
returnCC 
OkCC 
(CC 
newCC 
ApiResponseCC %
(CC% &
LocalizationServiceCC& 9
,CC9 :
LoggerCC; A
)CCA B
.CCB C
OkCCC E
(CCE F
MapperDD 
.DD 
MapDD 
<DD 
IEnumerableDD &
<DD& '
ClaimDD' ,
>DD, -
,DD- .
IEnumerableDD/ :
<DD: ;
ClaimResponseDD; H
>DDH I
>DDI J
(DDJ K
resultDDK Q
.DDQ R

ResultListDDR \
)DD\ ]
,DD] ^
resultEE 
.EE 
CountEE 
)EE 
)EE 
;EE 
}FF 	
}GG 
}HH £R
{C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseUserController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class 
BaseUserController #
:$ %+
BaseControllerWithAuthorization& E
<E F
UserF J
,J K
UserRequestL W
,W X
UserResponseY e
,e f
IUserManagerg s
,s t
intu x
>x y
{ 
public 
BaseUserController !
(! "
IUserManager" .
userManager/ :
,: ; 
ILocalizationService< P
localizationServiceQ d
,d e
ILoggerf m
<m n
BaseUserController	n Ä
>
Ä Å
logger
Ç à
,
à â
IMapper
ä ë
mapper
í ò
)
ò ô
: 
base 
( 
userManager 
, 
localizationService  3
,3 4
logger5 ;
,; <
mapper= C
)C D
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
User 
)  
,  !
Crud" &
.& '
Create' -
)- .
]. /
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :
UserRequest; F
requestG N
)N O
{ 	
return   
await   

BaseCreate   #
(  # $
request  $ +
)  + ,
;  , -
}!! 	
[## 	
Route##	 
(## 
$str##  
)##  !
]##! "
[$$ 	

HttpDelete$$	 
]$$ 
[%% 	

Permission%%	 
(%% 
nameof%% 
(%% 
User%% 
)%%  
,%%  !
Crud%%" &
.%%& '
Delete%%' -
)%%- .
]%%. /
public&& 
async&& 
Task&& 
<&& 
IActionResult&& '
>&&' (
Delete&&) /
(&&/ 0
int&&0 3
id&&4 6
)&&6 7
{'' 	
return(( 
await(( 

BaseDelete(( #
(((# $
id(($ &
)((& '
;((' (
})) 	
[++ 	
Route++	 
(++ 
$str++ 
)++ 
]++ 
[,, 	
HttpGet,,	 
],, 
[-- 	

Permission--	 
(-- 
nameof-- 
(-- 
User-- 
)--  
,--  !
Crud--" &
.--& '
Select--' -
)--- .
]--. /
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
GetById..) 0
(..0 1
int..1 4
id..5 7
)..7 8
{// 	
return00 
await00 
BaseGetById00 $
(00$ %
id00% '
)00' (
;00( )
}11 	
[33 	
Route33	 
(33 
$str33 )
)33) *
]33* +
[44 	
HttpPut44	 
]44 
[55 	

Permission55	 
(55 
nameof55 
(55 
User55 
)55  
,55  !
Crud55" &
.55& '
Update55' -
)55- .
]55. /
public66 
async66 
Task66 
<66 
IActionResult66 '
>66' (
UpdateUsername66) 7
(667 8
int668 ;
id66< >
,66> ?
[66@ A
FromBody66A I
]66I J
string66K Q
userName66R Z
)66Z [
{77 	
var88 
result88 
=88 
await88 
Manager88 &
.88& '
UpdateUserNameAsync88' :
(88: ;
id88; =
,88= >
userName88? G
)88G H
;88H I
return99 
Ok99 
(99 
new99 
ApiResponse99 %
(99% &
LocalizationService99& 9
,999 :
Logger99; A
)99A B
.99B C
Ok99C E
(99E F
Mapper99F L
.99L M
Map99M P
<99P Q
User99Q U
,99U V
UserResponse99W c
>99c d
(99d e
result99e k
)99k l
)99l m
)99m n
;99n o
}:: 	
[<< 	
Route<<	 
(<< 
$str<< )
)<<) *
]<<* +
[== 	
HttpPut==	 
]== 
[>> 	

Permission>>	 
(>> 
nameof>> 
(>> 
User>> 
)>>  
,>>  !
Crud>>" &
.>>& '
Update>>' -
)>>- .
]>>. /
public?? 
async?? 
Task?? 
<?? 
IActionResult?? '
>??' (
UpdatePassword??) 7
(??7 8
int??8 ;
id??< >
,??> ?
[??@ A
FromBody??A I
]??I J
string??K Q
password??R Z
)??Z [
{@@ 	
varAA 
resultAA 
=AA 
awaitAA 
ManagerAA &
.AA& '
UpdatePasswordAsyncAA' :
(AA: ;
idAA; =
,AA= >
passwordAA? G
)AAG H
;AAH I
returnBB 
OkBB 
(BB 
newBB 
ApiResponseBB %
(BB% &
LocalizationServiceBB& 9
,BB9 :
LoggerBB; A
)BBA B
.BBB C
OkBBC E
(BBE F
MapperBBF L
.BBL M
MapBBM P
<BBP Q
UserBBQ U
,BBU V
UserResponseBBW c
>BBc d
(BBd e
resultBBe k
)BBk l
)BBl m
)BBm n
;BBn o
}CC 	
[EE 	
RouteEE	 
(EE 
$strEE &
)EE& '
]EE' (
[FF 	
HttpPutFF	 
]FF 
[GG 	

PermissionGG	 
(GG 
nameofGG 
(GG 
UserGG 
)GG  
,GG  !
CrudGG" &
.GG& '
UpdateGG' -
)GG- .
]GG. /
publicHH 
asyncHH 
TaskHH 
<HH 
IActionResultHH '
>HH' (
UpdateEmailHH) 4
(HH4 5
intHH5 8
idHH9 ;
,HH; <
[HH= >
FromBodyHH> F
]HHF G
stringHHI O
emailHHP U
)HHU V
{II 	
varJJ 
resultJJ 
=JJ 
awaitJJ 
ManagerJJ &
.JJ& '
UpdateEmailAsyncJJ' 7
(JJ7 8
idJJ8 :
,JJ: ;
emailJJ< A
)JJA B
;JJB C
returnKK 
OkKK 
(KK 
newKK 
ApiResponseKK %
(KK% &
LocalizationServiceKK& 9
,KK9 :
LoggerKK; A
)KKA B
.KKB C
OkKKC E
(KKE F
MapperKKF L
.KKL M
MapKKM P
<KKP Q
UserKKQ U
,KKU V
UserResponseKKW c
>KKc d
(KKd e
resultKKe k
)KKk l
)KKl m
)KKm n
;KKn o
}LL 	
[NN 	
RouteNN	 
(NN 
$strNN (
)NN( )
]NN) *
[OO 	
HttpGetOO	 
]OO 
[PP 	

PermissionPP	 
(PP 
nameofPP 
(PP 
UserPP 
)PP  
,PP  !
CrudPP" &
.PP& '
SelectPP' -
)PP- .
]PP. /
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ '
>QQ' (
GetByUserNameQQ) 6
(QQ6 7
stringQQ7 =
userNameQQ> F
)QQF G
{RR 	
varTT 
resultTT 
=TT 
awaitTT 
ManagerTT &
.TT& '
GetByUserNameAsyncTT' 9
(TT9 :
userNameTT: B
)TTB C
;TTC D
returnUU 
OkUU 
(UU 
newUU 
ApiResponseUU %
(UU% &
LocalizationServiceUU& 9
,UU9 :
LoggerUU; A
)UUA B
.UUB C
OkUUC E
(UUE F
MapperUUF L
.UUL M
MapUUM P
<UUP Q
UserUUQ U
,UUU V
UserResponseUUW c
>UUc d
(UUd e
resultUUe k
)UUk l
)UUl m
)UUm n
;UUn o
}VV 	
[XX 	
RouteXX	 
(XX 
$strXX "
)XX" #
]XX# $
[YY 	
HttpGetYY	 
]YY 
[ZZ 	

PermissionZZ	 
(ZZ 
nameofZZ 
(ZZ 
UserZZ 
)ZZ  
,ZZ  !
CrudZZ" &
.ZZ& '
SelectZZ' -
)ZZ- .
]ZZ. /
public[[ 
async[[ 
Task[[ 
<[[ 
IActionResult[[ '
>[[' (

GetByEmail[[) 3
([[3 4
string[[4 :
email[[; @
)[[@ A
{\\ 	
var]] 
result]] 
=]] 
await]] 
Manager]] &
.]]& '
GetByEmailAsync]]' 6
(]]6 7
email]]7 <
)]]< =
;]]= >
return^^ 
Ok^^ 
(^^ 
new^^ 
ApiResponse^^ %
(^^% &
LocalizationService^^& 9
,^^9 :
Logger^^; A
)^^A B
.^^B C
Ok^^C E
(^^E F
Mapper^^F L
.^^L M
Map^^M P
<^^P Q
User^^Q U
,^^U V
UserResponse^^W c
>^^c d
(^^d e
result^^e k
)^^k l
)^^l m
)^^m n
;^^n o
}__ 	
}`` 
}aa ‘=
ÜC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseUserEntityClaimController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class )
BaseUserEntityClaimController .
:/ 04
(BaseControllerWithAuthorizationAndUpdate1 Y
<Y Z
UserEntityClaimZ i
,i j#
UserEntityClaimRequest	k Å
,
Å Ç 
EntityClaimRequest
É ï
,
ï ñ%
UserEntityClaimResponse
ó Æ
,
Æ Ø%
IUserEntityClaimManager
∞ «
,
« »
int
… Ã
>
Ã Õ
{ 
public )
BaseUserEntityClaimController ,
(, -#
IUserEntityClaimManager- D"
userEntityClaimManagerE [
,[ \ 
ILocalizationService] q 
localizationService	r Ö
,
Ö Ü
ILogger
á é
<
é è+
BaseUserEntityClaimController
è ¨
>
¨ ≠
logger
Æ ¥
,
¥ µ
IMapper
∂ Ω
mapper
æ ƒ
)
ƒ ≈
: 
base 
( "
userEntityClaimManager )
,) *
localizationService+ >
,> ?
logger@ F
,F G
mapperH N
)N O
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
UserEntityClaim *
)* +
,+ ,
Crud- 1
.1 2
Create2 8
)8 9
]9 :
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :"
UserEntityClaimRequest; Q
requestR Y
)Y Z
{ 	
return 
await 

BaseCreate #
(# $
request$ +
)+ ,
;, -
}   	
["" 	
Route""	 
("" 
$str"" 
)"" 
]"" 
[## 	
HttpPut##	 
]## 
[$$ 	

Permission$$	 
($$ 
nameof$$ 
($$ 
UserEntityClaim$$ *
)$$* +
,$$+ ,
Crud$$- 1
.$$1 2
Update$$2 8
)$$8 9
]$$9 :
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
Update%%) /
(%%/ 0
int%%0 3
id%%4 6
,%%6 7
[%%8 9
FromBody%%9 A
]%%A B
EntityClaimRequest%%C U
request%%V ]
)%%] ^
{&& 	
return'' 
await'' 

BaseUpdate'' #
(''# $
id''$ &
,''& '
request''( /
)''/ 0
;''0 1
}(( 	
[** 	
Route**	 
(** 
$str**  
)**  !
]**! "
[++ 	

HttpDelete++	 
]++ 
[,, 	

Permission,,	 
(,, 
nameof,, 
(,, 
UserEntityClaim,, *
),,* +
,,,+ ,
Crud,,- 1
.,,1 2
Delete,,2 8
),,8 9
],,9 :
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
Delete--) /
(--/ 0
int--0 3
id--4 6
)--6 7
{.. 	
return// 
await// 

BaseDelete// #
(//# $
id//$ &
)//& '
;//' (
}00 	
[22 	
Route22	 
(22 
$str22 
)22 
]22 
[33 	
HttpGet33	 
]33 
[44 	

Permission44	 
(44 
nameof44 
(44 
UserEntityClaim44 *
)44* +
,44+ ,
Crud44- 1
.441 2
Select442 8
)448 9
]449 :
public55 
async55 
Task55 
<55 
IActionResult55 '
>55' (
GetById55) 0
(550 1
int551 4
id555 7
)557 8
{66 	
return77 
await77 
BaseGetById77 $
(77$ %
id77% '
)77' (
;77( )
}88 	
[:: 	
Route::	 
(:: 
$str:: '
)::' (
]::( )
[;; 	
HttpGet;;	 
];; 
[<< 	

Permission<<	 
(<< 
nameof<< 
(<< 
UserEntityClaim<< *
)<<* +
,<<+ ,
Crud<<- 1
.<<1 2
Select<<2 8
)<<8 9
]<<9 :
public== 
async== 
Task== 
<== 
IActionResult== '
>==' (
GetAllByEntity==) 7
(==7 8
string==8 >
entity==? E
)==E F
{>> 	
var?? 
result?? 
=?? 
await?? 
Manager?? &
.??& '
GetAllByEntityAsync??' :
(??: ;
entity??; A
)??A B
;??B C
return@@ 
Ok@@ 
(@@ 
new@@ 
ApiResponse@@ %
(@@% &
LocalizationService@@& 9
,@@9 :
Logger@@; A
)@@A B
.@@B C
Ok@@C E
(@@E F
MapperAA 
.AA 
MapAA 
<AA 
IListAA  
<AA  !
UserEntityClaimAA! 0
>AA0 1
,AA1 2
IListAA3 8
<AA8 9#
UserEntityClaimResponseAA9 P
>AAP Q
>AAQ R
(AAR S
resultAAS Y
.AAY Z

ResultListAAZ d
)AAd e
,AAe f
resultBB 
.BB 
CountBB 
)BB 
)BB 
;BB 
}CC 	
[EE 	
RouteEE	 
(EE 
$strEE +
)EE+ ,
]EE, -
[FF 	
HttpGetFF	 
]FF 
[GG 	

PermissionGG	 
(GG 
nameofGG 
(GG 
UserEntityClaimGG *
)GG* +
,GG+ ,
CrudGG- 1
.GG1 2
SelectGG2 8
)GG8 9
]GG9 :
publicHH 
asyncHH 
TaskHH 
<HH 
IActionResultHH '
>HH' (
GetAllByUserIdHH) 7
(HH7 8
intHH8 ;
userIdHH< B
)HHB C
{II 	
varJJ 
resultJJ 
=JJ 
awaitJJ 
ManagerJJ &
.JJ& '
GetAllByUserIdAsyncJJ' :
(JJ: ;
userIdJJ; A
)JJA B
;JJB C
returnKK 
OkKK 
(KK 
newKK 
ApiResponseKK %
(KK% &
LocalizationServiceKK& 9
,KK9 :
LoggerKK; A
)KKA B
.KKB C
OkKKC E
(KKE F
MapperLL 
.LL 
MapLL 
<LL 
IListLL  
<LL  !
UserEntityClaimLL! 0
>LL0 1
,LL1 2
IListLL3 8
<LL8 9#
UserEntityClaimResponseLL9 P
>LLP Q
>LLQ R
(LLR S
resultLLS Y
.LLY Z

ResultListLLZ d
)LLd e
,LLe f
resultMM 
.MM 
CountMM 
)MM 
)MM 
;MM 
}NN 	
}OO 
}PP Û4
C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Controllers\BaseUserRoleController.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Controllers4 ?
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
true% )
)) *
]* +
public 

class "
BaseUserRoleController '
:( )+
BaseControllerWithAuthorization* I
<I J
UserRoleJ R
,R S
UserRoleRequestT c
,c d
UserRoleResponsee u
,u v
IUserRoleManager	w á
,
á à
int
â å
>
å ç
{ 
public "
BaseUserRoleController %
(% &
IUserRoleManager& 6
userRoleManager7 F
,F G 
ILocalizationServiceH \
localizationService] p
,p q
ILoggerr y
<y z#
BaseUserRoleController	z ê
>
ê ë
logger
í ò
,
ò ô
IMapper
ö °
mapper
¢ ®
)
® ©
: 
base 
( 
userRoleManager "
," #
localizationService$ 7
,7 8
logger9 ?
,? @
mapperA G
)G H
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
UserRole #
)# $
,$ %
Crud& *
.* +
Create+ 1
)1 2
]2 3
public 
async 
Task 
< 
IActionResult '
>' (
Create) /
(/ 0
[0 1
FromBody1 9
]9 :
UserRoleRequest; J
requestK R
)R S
{ 	
return 
await 

BaseCreate #
(# $
request$ +
)+ ,
;, -
}   	
["" 	
Route""	 
("" 
$str""  
)""  !
]""! "
[## 	

HttpDelete##	 
]## 
[$$ 	

Permission$$	 
($$ 
nameof$$ 
($$ 
UserRole$$ #
)$$# $
,$$$ %
Crud$$& *
.$$* +
Delete$$+ 1
)$$1 2
]$$2 3
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
Delete%%) /
(%%/ 0
int%%0 3
id%%4 6
)%%6 7
{&& 	
return'' 
await'' 

BaseDelete'' #
(''# $
id''$ &
)''& '
;''' (
}(( 	
[** 	
Route**	 
(** 
$str** 
)** 
]** 
[++ 	
HttpGet++	 
]++ 
[,, 	

Permission,,	 
(,, 
nameof,, 
(,, 
UserRole,, #
),,# $
,,,$ %
Crud,,& *
.,,* +
Select,,+ 1
),,1 2
],,2 3
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
GetById--) 0
(--0 1
int--1 4
id--5 7
)--7 8
{.. 	
return// 
await// 
BaseGetById// $
(//$ %
id//% '
)//' (
;//( )
}00 	
[22 	
Route22	 
(22 
$str22 .
)22. /
]22/ 0
[33 	
HttpGet33	 
]33 
[44 	

Permission44	 
(44 
nameof44 
(44 
UserRole44 #
)44# $
,44$ %
Crud44& *
.44* +
Select44+ 1
)441 2
]442 3
public55 
async55 
Task55 
<55 
IActionResult55 '
>55' (
GetUsersByRoleId55) 9
(559 :
int55: =
roleId55> D
)55D E
{66 	
var77 
result77 
=77 
await77 
Manager77 &
.77& '!
GetUsersByRoleIdAsync77' <
(77< =
roleId77= C
)77C D
;77D E
return88 
Ok88 
(88 
new88 
ApiResponse88 %
(88% &
LocalizationService88& 9
,889 :
Logger88; A
)88A B
.88B C
Ok88C E
(88E F
Mapper99 
.99 
Map99 
<99 
IList99  
<99  !
User99! %
>99% &
,99& '
IList99( -
<99- .
UserResponse99. :
>99: ;
>99; <
(99< =
result99= C
.99C D

ResultList99D N
)99N O
,99O P
result:: 
.:: 
Count:: 
):: 
):: 
;:: 
};; 	
[== 	
Route==	 
(== 
$str== -
)==- .
]==. /
[>> 	
HttpGet>>	 
]>> 
[?? 	

Permission??	 
(?? 
nameof?? 
(?? 
UserRole?? #
)??# $
,??$ %
Crud??& *
.??* +
Select??+ 1
)??1 2
]??2 3
public@@ 
async@@ 
Task@@ 
<@@ 
IActionResult@@ '
>@@' (
GetRolesByUserId@@) 9
(@@9 :
int@@: =
userId@@> D
)@@D E
{AA 	
varBB 
resultBB 
=BB 
awaitBB 
ManagerBB &
.BB& '!
GetRolesByUserIdAsyncBB' <
(BB< =
userIdBB= C
)BBC D
;BBD E
returnCC 
OkCC 
(CC 
newCC 
ApiResponseCC %
(CC% &
LocalizationServiceCC& 9
,CC9 :
LoggerCC; A
)CCA B
.CCB C
OkCCC E
(CCE F
MapperDD 
.DD 
MapDD 
<DD 
IListDD  
<DD  !
RoleDD! %
>DD% &
,DD& '
IListDD( -
<DD- .
RoleResponseDD. :
>DD: ;
>DD; <
(DD< =
resultDD= C
.DDC D

ResultListDDD N
)DDN O
,DDO P
resultEE 
.EE 
CountEE 
)EE 
)EE 
;EE 
}FF 	
}HH 
}II ‹2
vC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\AuthorizationContext.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
{ 
public 

class  
AuthorizationContext %
:& '
	DbContext( 1
{ 
public  
AuthorizationContext #
(# $
DbContextOptions$ 4
options5 <
)< =
: 
base 
( 
options 
) 
{ 	
} 	
public 
virtual 
DbSet 
< 
ClientApplication .
>. /
ClientApplications0 B
{C D
getE H
;H I
setJ M
;M N
}O P
public 
virtual 
DbSet 
< !
ClientApplicationUtil 2
>2 3"
ClientApplicationUtils4 J
{K L
getM P
;P Q
setR U
;U V
}W X
public 
virtual 
DbSet 
< 
User !
>! "
Users# (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
virtual 
DbSet 
< 
Role !
>! "
Roles# (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
virtual 
DbSet 
< 
Claim "
>" #
Claims$ *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
virtual 
DbSet 
< 
	RoleClaim &
>& '

RoleClaims( 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
virtual 
DbSet 
< 
	UserClaim &
>& '

UserClaims( 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
virtual 
DbSet 
< 
UserRole %
>% &
	UserRoles' 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
virtual 
DbSet 
< 
UserUtil %
>% &
	UserUtils' 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
virtual 
DbSet 
< 
RoleEntityClaim ,
>, -
RoleEntityClaims. >
{? @
getA D
;D E
setF I
;I J
}K L
public 
virtual 
DbSet 
< 
UserEntityClaim ,
>, -
UserEntityClaims. >
{? @
getA D
;D E
setF I
;I J
}K L
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
modelBuilder!! 
.!! 
ApplyConfiguration!! +
(!!+ ,
new!!, //
#ClientApplicationModelConfiguration!!0 S
<!!S T
ClientApplication!!T e
>!!e f
(!!f g
)!!g h
)!!h i
;!!i j
modelBuilder"" 
."" 
ApplyConfiguration"" +
(""+ ,
new"", /3
'ClientApplicationUtilModelConfiguration""0 W
<""W X!
ClientApplicationUtil""X m
>""m n
(""n o
)""o p
)""p q
;""q r
modelBuilder## 
.## 
ApplyConfiguration## +
(##+ ,
new##, /"
UserModelConfiguration##0 F
<##F G
User##G K
>##K L
(##L M
)##M N
)##N O
;##O P
modelBuilder$$ 
.$$ 
ApplyConfiguration$$ +
($$+ ,
new$$, /"
RoleModelConfiguration$$0 F
<$$F G
Role$$G K
>$$K L
($$L M
)$$M N
)$$N O
;$$O P
modelBuilder%% 
.%% 
ApplyConfiguration%% +
(%%+ ,
new%%, /#
ClaimModelConfiguration%%0 G
<%%G H
Claim%%H M
>%%M N
(%%N O
)%%O P
)%%P Q
;%%Q R
modelBuilder&& 
.&& 
ApplyConfiguration&& +
(&&+ ,
new&&, /'
RoleClaimModelConfiguration&&0 K
<&&K L
	RoleClaim&&L U
>&&U V
(&&V W
)&&W X
)&&X Y
;&&Y Z
modelBuilder'' 
.'' 
ApplyConfiguration'' +
(''+ ,
new'', /'
UserClaimModelConfiguration''0 K
<''K L
	UserClaim''L U
>''U V
(''V W
)''W X
)''X Y
;''Y Z
modelBuilder(( 
.(( 
ApplyConfiguration(( +
(((+ ,
new((, /&
UserRoleModelConfiguration((0 J
<((J K
UserRole((K S
>((S T
(((T U
)((U V
)((V W
;((W X
modelBuilder)) 
.)) 
ApplyConfiguration)) +
())+ ,
new)), /&
UserUtilModelConfiguration))0 J
<))J K
UserUtil))K S
>))S T
())T U
)))U V
)))V W
;))W X
modelBuilder** 
.** 
ApplyConfiguration** +
(**+ ,
new**, /-
!RoleEntityClaimModelConfiguration**0 Q
<**Q R
RoleEntityClaim**R a
>**a b
(**b c
)**c d
)**d e
;**e f
modelBuilder++ 
.++ 
ApplyConfiguration++ +
(+++ ,
new++, /-
!UserEntityClaimModelConfiguration++0 Q
<++Q R
UserEntityClaim++R a
>++a b
(++b c
)++c d
)++d e
;++e f
},, 	
}-- 
}.. ∏
ÜC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\BaseDataInitializer.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
DataInitializers9 I
{ 
public 

class 
BaseDataInitializer $
{ 
	protected 
readonly 
IUnitOfWork &

UnitOfWork' 1
;1 2
public		 
BaseDataInitializer		 "
(		" #
IUnitOfWork		# .

unitOfWork		/ 9
)		9 :
{

 	

UnitOfWork 
= 

unitOfWork #
;# $
} 	
} 
} „,
ìC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\ClientApplicationDataInitializer.cs
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
% &
Authorization

& 3
.

3 4
Data

4 8
.

8 9
DataInitializers

9 I
{ 
public 

class ,
 ClientApplicationDataInitializer 1
:2 3
BaseDataInitializer4 G
{ 
public ,
 ClientApplicationDataInitializer /
(/ 0
IUnitOfWork0 ;

unitOfWork< F
)F G
:H I
baseJ N
(N O

unitOfWorkO Y
)Y Z
{ 	
} 	
public 
async 
Task 
Seed 
( 
)  
{ 	
var 
roles 
= 
ConfigHelper $
.$ %

GetSection% /
(/ 0
$str0 C
)C D
;D E
foreach 
( 
var 
section  
in! #
roles$ )
.) *
GetChildren* 5
(5 6
)6 7
)7 8
{ 
var 
name 
= 
section "
." #
GetValue# +
<+ ,
string, 2
>2 3
(3 4
$str4 :
): ;
;; <
var 
code 
= 
section "
." #
GetValue# +
<+ ,
string, 2
>2 3
(3 4
$str4 :
): ;
;; <
var 
password 
= 
section &
.& '
GetValue' /
</ 0
string0 6
>6 7
(7 8
$str8 B
)B C
;C D
if 
( ,
 GetClientApplicationsByNameAsync 4
(4 5
name5 9
)9 :
.: ;
Result; A
.A B
CountB G
>H I
$numJ K
)K L
continueM U
;U V
var 
hashedPassword "
=# $
password% -
.- .
HashPassword. :
(: ;
out; >
var? B
saltC G
,G H
ConvertI P
.P Q
ToInt32Q X
(X Y
ConfigHelperY e
.e f!
GetConfigurationValuef {
({ |
$str	| ò
)
ò ô
)
ô ö
)
ö õ
;
õ ú
var 
clientApplication %
=& '
new( +
ClientApplication, =
{   !
ClientApplicationName!! )
=!!* +
name!!, 0
,!!0 1!
ClientApplicationCode"" )
=""* +
code"", 0
,""0 1%
ClientApplicationPassword## -
=##. /
hashedPassword##0 >
,##> ?
}$$ 
;$$ 

UnitOfWork&& 
.&& 
GetRepository&& (
<&&( )
ClientApplication&&) :
,&&: ;
int&&< ?
>&&? @
(&&@ A
)&&A B
.&&B C
Add&&C F
(&&F G
clientApplication&&G X
)&&X Y
;&&Y Z
await(( 

UnitOfWork((  
.((  !
SaveChangesAsync((! 1
(((1 2
)((2 3
;((3 4
await** ,
 CreateClientApplicationUtilAsync** 6
(**6 7
clientApplication**7 H
.**H I
Id**I K
,**K L
salt**M Q
)**Q R
;**R S
}++ 
},, 	
private.. 
async.. 
Task.. 
<.. 
IList..  
<..  !
ClientApplication..! 2
>..2 3
>..3 4,
 GetClientApplicationsByNameAsync..5 U
(..U V
string..V \
name..] a
)..a b
{// 	
return00 
await00 

UnitOfWork00 #
.00# $
GetRepository00$ 1
<001 2
ClientApplication002 C
,00C D
int00E H
>00H I
(00I J
)00J K
.11 
GetAll11 
(11 
	predicate11 !
:11! "
p11# $
=>11% '
p11( )
.11) *!
ClientApplicationName11* ?
==11@ B
name11C G
)11G H
.11H I
ToListAsync11I T
(11T U
)11U V
;11V W
}22 	
private44 
async44 
Task44 ,
 CreateClientApplicationUtilAsync44 ;
(44; <
int44< ?
clientApplicationId44@ S
,44S T
string44U [
salt44\ `
)44` a
{55 	
var66 !
clientApplicationUtil66 %
=66& '
new66( +!
ClientApplicationUtil66, A
(66A B
)66B C
{77 
ClientApplicationId88 #
=88$ %
clientApplicationId88& 9
,889 :
SpecialValue99 
=99 
salt99 #
,99# $
}:: 
;:: 

UnitOfWork<< 
.<< 
GetRepository<< $
<<<$ %!
ClientApplicationUtil<<% :
,<<: ;
int<<< ?
><<? @
(<<@ A
)<<A B
.<<B C
Add<<C F
(<<F G!
clientApplicationUtil<<G \
)<<\ ]
;<<] ^
await== 

UnitOfWork== 
.== 
SaveChangesAsync== -
(==- .
)==. /
;==/ 0
}>> 	
}?? 
}@@ ©	
àC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\DataInitializerHelper.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
DataInitializers9 I
{ 
public 

static 
class !
DataInitializerHelper -
{ 
public 
static 
string 
HashPassword )
() *
this* .
string/ 5
password6 >
,> ?
out@ C
stringD J
saltK O
,O P
intQ T
iterationCountU c
)c d
{ 	
salt		 
=		 

HashString		 
.		 
GetSalt		 %
(		% &
)		& '
;		' (
return

 

HashString

 
.

 
Hash

 "
(

" #
password

# +
,

+ ,
salt

- 1
,

1 2
iterationCount

3 A
)

A B
;

B C
} 	
} 
} á
ÜC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\RoleDataInitializer.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Data		4 8
.		8 9
DataInitializers		9 I
{

 
public 

class 
RoleDataInitializer $
:% &
BaseDataInitializer' :
{ 
public 
RoleDataInitializer "
(" #
IUnitOfWork# .

unitOfWork/ 9
)9 :
:; <
base= A
(A B

unitOfWorkB L
)L M
{ 	
} 	
public 
async 
Task 
Seed 
( 
)  
{ 	
var 
roles 
= 
ConfigHelper $
.$ %

GetSection% /
(/ 0
$str0 7
)7 8
;8 9
foreach 
( 
var 
section  
in! #
roles$ )
.) *
GetChildren* 5
(5 6
)6 7
)7 8
{ 
var 
name 
= 
section "
." #
GetValue# +
<+ ,
string, 2
>2 3
(3 4
$str4 :
): ;
;; <
if 
( 
GetRolesByNameAsync '
(' (
name( ,
), -
.- .
Result. 4
.4 5
Count5 :
>; <
$num= >
)> ?
continue@ H
;H I
var 
role 
= 
new 
Role #
{ 
RoleName 
= 
name #
,# $
} 
; 

UnitOfWork   
.   
GetRepository   (
<  ( )
Role  ) -
,  - .
int  / 2
>  2 3
(  3 4
)  4 5
.  5 6
Add  6 9
(  9 :
role  : >
)  > ?
;  ? @
await!! 

UnitOfWork!!  
.!!  !
SaveChangesAsync!!! 1
(!!1 2
)!!2 3
;!!3 4
}"" 
}## 	
private%% 
async%% 
Task%% 
<%% 
IList%%  
<%%  !
Role%%! %
>%%% &
>%%& '
GetRolesByNameAsync%%( ;
(%%; <
string%%< B
name%%C G
)%%G H
{&& 	
return'' 
await'' 

UnitOfWork'' #
.''# $
GetRepository''$ 1
<''1 2
Role''2 6
,''6 7
int''8 ;
>''; <
(''< =
)''= >
.(( 
GetAll(( 
((( 
	predicate(( "
:((" #
p(($ %
=>((& (
p(() *
.((* +
RoleName((+ 3
==((4 6
name((7 ;
)((; <
.((< =
ToListAsync((= H
(((H I
)((I J
;((J K
})) 	
}** 
}++ æ7
ëC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\RoleEntityClaimDataInitializer.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
DataInitializers9 I
{ 
public 

class *
RoleEntityClaimDataInitializer /
:0 1
BaseDataInitializer2 E
{ 
public *
RoleEntityClaimDataInitializer -
(- .
IUnitOfWork. 9

unitOfWork: D
)D E
:F G
baseH L
(L M

unitOfWorkM W
)W X
{ 	
} 	
public 
async 
Task 
Seed 
( 
)  
{ 	
var 
roleEntityClaims  
=! "
ConfigHelper# /
./ 0

GetSection0 :
(: ;
$str; L
)L M
;M N
foreach 
( 
var 
section  
in! #
roleEntityClaims$ 4
.4 5
GetChildren5 @
(@ A
)A B
)B C
{ 
var 
roleName 
= 
section &
.& '
GetValue' /
</ 0
string0 6
>6 7
(7 8
$str8 B
)B C
;C D
var 
role 
= 
GetRolesByNameAsync .
(. /
roleName/ 7
)7 8
.8 9
Result9 ?
[? @
$num@ A
]A B
;B C
var 
entitiesString "
=# $
section% ,
., -

GetSection- 7
(7 8
$str8 B
)B C
.C D
GetD G
<G H
stringH N
[N O
]O P
>P Q
(Q R
)R S
;S T
if!! 
(!! 
entitiesString!! "
==!!# %
null!!& *
)!!* +
continue!!, 4
;!!4 5
var## 
entities## 
=## 
new## "
List### '
<##' (
string##( .
>##. /
(##/ 0
)##0 1
;##1 2
if%% 
(%% 
entitiesString%% "
[%%" #
$num%%# $
]%%$ %
==%%& (
$str%%) .
)%%. /
entities&& 
=&& 
Enum&& #
.&&# $
	GetValues&&$ -
(&&- .
typeof&&. 4
(&&4 5
string&&5 ;
)&&; <
)&&< =
.&&= >
Cast&&> B
<&&B C
string&&C I
>&&I J
(&&J K
)&&K L
.&&L M
ToList&&M S
(&&S T
)&&T U
;&&U V
else'' 
entities(( 
.(( 
AddRange(( %
(((% &
entitiesString((& 4
.((4 5
Select((5 ;
(((; <
s((< =
=>((> @
(((A B
string((B H
)((H I
Enum((I M
.((M N
Parse((N S
(((S T
typeof((T Z
(((Z [
string(([ a
)((a b
,((b c
s((d e
)((e f
)((f g
)((g h
;((h i
foreach** 
(** 
var** 
entity** #
in**$ &
entities**' /
)**/ 0
{++ 
if,, 
(,, 5
)GetRoleEntityClaimsByRoleIdAndEntityAsync,, A
(,,A B
role,,B F
.,,F G
Id,,G I
,,,I J
entity,,K Q
),,Q R
.,,R S
Result,,S Y
.,,Y Z
Count,,Z _
>,,` a
$num,,b c
),,c d
continue,,e m
;,,m n
var.. 
roleEntityClaim.. '
=..( )
new..* -
RoleEntityClaim... =
(..= >
)..> ?
{// 
Entity00 
=00  
entity00! '
,00' (
RoleId11 
=11  
role11! %
.11% &
Id11& (
,11( )
	CanDelete22 !
=22" #
true22$ (
,22( )
	CanSelect33 !
=33" #
true33$ (
,33( )
	CanCreate44 !
=44" #
true44$ (
,44( )
	CanUpdate55 !
=55" #
true55$ (
,55( )
}66 
;66 

UnitOfWork88 
.88 
GetRepository88 ,
<88, -
RoleEntityClaim88- <
,88< =
int88> A
>88A B
(88B C
)88C D
.88D E
Add88E H
(88H I
roleEntityClaim88I X
)88X Y
;88Y Z
await:: 

UnitOfWork:: $
.::$ %
SaveChangesAsync::% 5
(::5 6
)::6 7
;::7 8
};; 
}<< 
}== 	
private?? 
async?? 
Task?? 
<?? 
IList??  
<??  !
RoleEntityClaim??! 0
>??0 1
>??1 25
)GetRoleEntityClaimsByRoleIdAndEntityAsync??3 \
(??\ ]
int??] `
roleId??a g
,??g h
string??i o
entity??p v
)??v w
{@@ 	
returnAA 
awaitAA 

UnitOfWorkAA #
.AA# $
GetRepositoryAA$ 1
<AA1 2
RoleEntityClaimAA2 A
,AAA B
intAAC F
>AAF G
(AAG H
)AAH I
.BB 
GetAllBB 
(BB 
	predicateBB "
:BB" #
pBB$ %
=>BB& (
pBB) *
.BB* +
RoleIdBB+ 1
==BB2 4
roleIdBB5 ;
&&BB< >
pBB? @
.BB@ A
EntityBBA G
==BBH J
entityBBK Q
)BBQ R
.BBR S
SelectBBS Y
(BBY Z
pBBZ [
=>BB\ ^
pBB_ `
)BB` a
.BBa b
ToListAsyncBBb m
(BBm n
)BBn o
;BBo p
}CC 	
privateEE 
asyncEE 
TaskEE 
<EE 
IListEE  
<EE  !
RoleEE! %
>EE% &
>EE& '
GetRolesByNameAsyncEE( ;
(EE; <
stringEE< B
nameEEC G
)EEG H
{FF 	
returnGG 
awaitGG 

UnitOfWorkGG #
.GG# $
GetRepositoryGG$ 1
<GG1 2
RoleGG2 6
,GG6 7
intGG8 ;
>GG; <
(GG< =
)GG= >
.HH 
GetAllHH 
(HH 
	predicateHH !
:HH! "
pHH# $
=>HH% '
pHH( )
.HH) *
RoleNameHH* 2
==HH3 5
nameHH6 :
)HH: ;
.HH; <
SelectHH< B
(HHB C
pHHC D
=>HHE G
pHHH I
)HHI J
.HHJ K
ToListAsyncHHK V
(HHV W
)HHW X
;HHX Y
}II 	
}KK 
}LL ¶*
ÜC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\UserDataInitializer.cs
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
% &
Authorization

& 3
.

3 4
Data

4 8
.

8 9
DataInitializers

9 I
{ 
public 

class 
UserDataInitializer $
:% &
BaseDataInitializer' :
{ 
public 
UserDataInitializer "
(" #
IUnitOfWork# .

unitOfWork/ 9
)9 :
:; <
base= A
(A B

unitOfWorkB L
)L M
{ 	
} 	
public 
async 
Task 
Seed 
( 
)  
{ 	
var 
users 
= 
ConfigHelper $
.$ %

GetSection% /
(/ 0
$str0 7
)7 8
;8 9
foreach 
( 
var 
section  
in! #
users$ )
.) *
GetChildren* 5
(5 6
)6 7
)7 8
{ 
var 
userName 
= 
section &
.& '
GetValue' /
</ 0
string0 6
>6 7
(7 8
$str8 B
)B C
;C D
var 
email 
= 
section #
.# $
GetValue$ ,
<, -
string- 3
>3 4
(4 5
$str5 <
)< =
;= >
var 
password 
= 
section &
.& '
GetValue' /
</ 0
string0 6
>6 7
(7 8
$str8 B
)B C
;C D
if 
( #
GetUsersByUserNameAsync +
(+ ,
userName, 4
)4 5
.5 6
Result6 <
.< =
Count= B
>C D
$numE F
)F G
continueH P
;P Q
var 
hashedPassword "
=# $
password% -
.- .
HashPassword. :
(: ;
out; >
var? B
saltC G
,G H
ConvertI P
.P Q
ToInt32Q X
(X Y
ConfigHelperY e
.e f!
GetConfigurationValuef {
({ |
$str	| ò
)
ò ô
)
ô ö
)
ö õ
;
õ ú
var   
user   
=   
new   
User   #
{!! 
UserName"" 
="" 
userName"" '
,""' (
Email## 
=## 
email## !
,##! "
Password$$ 
=$$ 
hashedPassword$$ -
}%% 
;%% 

UnitOfWork'' 
.'' 
GetRepository'' (
<''( )
User'') -
,''- .
int''/ 2
>''2 3
(''3 4
)''4 5
.''5 6
Add''6 9
(''9 :
user'': >
)''> ?
;''? @
await)) 

UnitOfWork))  
.))  !
SaveChangesAsync))! 1
())1 2
)))2 3
;))3 4
await++ 
CreateUserUtilAsync++ )
(++) *
user++* .
.++. /
Id++/ 1
,++1 2
salt++3 7
)++7 8
;++8 9
},, 
}-- 	
private// 
async// 
Task// 
<// 
IList//  
<//  !
User//! %
>//% &
>//& '#
GetUsersByUserNameAsync//( ?
(//? @
string//@ F
userName//G O
)//O P
{00 	
return11 
await11 

UnitOfWork11 #
.11# $
GetRepository11$ 1
<111 2
User112 6
,116 7
int118 ;
>11; <
(11< =
)11= >
.22 
GetAll22 
(22 
	predicate22 !
:22! "
p22# $
=>22% '
p22( )
.22) *
UserName22* 2
==223 5
userName226 >
)22> ?
.22? @
ToListAsync22@ K
(22K L
)22L M
;22M N
}33 	
private55 
async55 
Task55 
CreateUserUtilAsync55 .
(55. /
int55/ 2
userId553 9
,559 :
string55; A
salt55B F
)55F G
{66 	
var77 
userUtil77 
=77 
new77 
UserUtil77 '
(77' (
)77( )
{88 
UserId99 
=99 
userId99 
,99  
SpecialValue:: 
=:: 
salt:: #
,::# $
};; 
;;; 

UnitOfWork== 
.== 
GetRepository== $
<==$ %
UserUtil==% -
,==- .
int==/ 2
>==2 3
(==3 4
)==4 5
.==5 6
Add==6 9
(==9 :
userUtil==: B
)==B C
;==C D
await?? 

UnitOfWork?? 
.?? 
SaveChangesAsync?? -
(??- .
)??. /
;??/ 0
}@@ 	
}BB 
}CC 0
äC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\DataInitializers\UserRoleDataInitializer.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Data		4 8
.		8 9
DataInitializers		9 I
{

 
public 

class #
UserRoleDataInitializer (
:) *
BaseDataInitializer+ >
{ 
public #
UserRoleDataInitializer &
(& '
IUnitOfWork' 2

unitOfWork3 =
)= >
:? @
baseA E
(E F

unitOfWorkF P
)P Q
{ 	
} 	
public 
async 
Task 
Seed 
( 
)  
{ 	
var 
users 
= 
ConfigHelper $
.$ %

GetSection% /
(/ 0
$str0 7
)7 8
;8 9
foreach 
( 
var 
section  
in! #
users$ )
.) *
GetChildren* 5
(5 6
)6 7
)7 8
{ 
var 
userName 
= 
section &
.& '
GetValue' /
</ 0
string0 6
>6 7
(7 8
$str8 B
)B C
;C D
var 
	userRoles 
= 
section  '
.' (

GetSection( 2
(2 3
$str3 :
): ;
.; <
Get< ?
<? @
string@ F
[F G
]G H
>H I
(I J
)J K
;K L
var 
user 
= #
GetUsersByUserNameAsync 2
(2 3
userName3 ;
); <
.< =
Result= C
[C D
$numD E
]E F
;F G
foreach 
( 
var 
roleName %
in& (
	userRoles) 2
)2 3
{ 
var 
role 
= 
GetRolesByNameAsync 2
(2 3
roleName3 ;
); <
.< =
Result= C
[C D
$numD E
]E F
;F G
if!! 
(!! .
"GetUserRolesByUserIdAndRoleIdAsync!! :
(!!: ;
role!!; ?
.!!? @
Id!!@ B
,!!B C
user!!D H
.!!H I
Id!!I K
)!!K L
.!!L M
Result!!M S
.!!S T
Count!!T Y
>!!Z [
$num!!\ ]
)!!] ^
continue!!_ g
;!!g h
var## 
userRole##  
=##! "
new### &
UserRole##' /
(##/ 0
)##0 1
{$$ 
UserId%% 
=%%  
user%%! %
.%%% &
Id%%& (
,%%( )
RoleId&& 
=&&  
role&&! %
.&&% &
Id&&& (
,&&( )
}'' 
;'' 

UnitOfWork)) 
.)) 
GetRepository)) ,
<)), -
UserRole))- 5
,))5 6
int))7 :
>)): ;
()); <
)))< =
.))= >
Add))> A
())A B
userRole))B J
)))J K
;))K L
}** 
await,, 

UnitOfWork,,  
.,,  !
SaveChangesAsync,,! 1
(,,1 2
),,2 3
;,,3 4
}-- 
}.. 	
private00 
async00 
Task00 
<00 
IList00  
<00  !
UserRole00! )
>00) *
>00* +.
"GetUserRolesByUserIdAndRoleIdAsync00, N
(00N O
int00O R
roleId00S Y
,00Y Z
int00[ ^
userId00_ e
)00e f
{11 	
return22 
await22 

UnitOfWork22 #
.22# $
GetRepository22$ 1
<221 2
UserRole222 :
,22: ;
int22< ?
>22? @
(22@ A
)22A B
.33 
GetAll33 
(33 
	predicate33 !
:33! "
p33# $
=>33% '
p33( )
.33) *
RoleId33* 0
==331 3
roleId334 :
&&33; =
p33> ?
.33? @
UserId33@ F
==33G I
userId33J P
)33P Q
.33Q R
ToListAsync33R ]
(33] ^
)33^ _
;33_ `
}44 	
private66 
async66 
Task66 
<66 
IList66  
<66  !
Role66! %
>66% &
>66& '
GetRolesByNameAsync66( ;
(66; <
string66< B
name66C G
)66G H
{77 	
return88 
await88 

UnitOfWork88 #
.88# $
GetRepository88$ 1
<881 2
Role882 6
,886 7
int888 ;
>88; <
(88< =
)88= >
.99 
GetAll99 
(99 
	predicate99 !
:99! "
p99# $
=>99% '
p99( )
.99) *
RoleName99* 2
==993 5
name996 :
)99: ;
.99; <
ToListAsync99< G
(99G H
)99H I
;99I J
}:: 	
private<< 
async<< 
Task<< 
<<< 
IList<<  
<<<  !
User<<! %
><<% &
><<& '#
GetUsersByUserNameAsync<<( ?
(<<? @
string<<@ F
userName<<G O
)<<O P
{== 	
return>> 
await>> 

UnitOfWork>> #
.>># $
GetRepository>>$ 1
<>>1 2
User>>2 6
,>>6 7
int>>8 ;
>>>; <
(>>< =
)>>= >
.?? 
GetAll?? 
(?? 
	predicate?? "
:??" #
p??$ %
=>??& (
p??) *
.??* +
UserName??+ 3
==??4 6
userName??7 ?
)??? @
.??@ A
ToListAsync??A L
(??L M
)??M N
;??N O
}@@ 	
}AA 
}BB ö
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\IUnitOfWorkAuthorization.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
{ 
public 

	interface $
IUnitOfWorkAuthorization -
:. /
IUnitOfWork0 ;
{ 
IClaimRepository		 
Claims		 
{		  !
get		" %
;		% &
}		' ((
IClientApplicationRepository

 $
ClientApplications

% 7
{

8 9
get

: =
;

= >
}

? @,
 IClientApplicationUtilRepository ("
ClientApplicationUtils) ?
{@ A
getB E
;E F
}G H 
IRoleClaimRepository 

RoleClaims '
{( )
get* -
;- .
}/ 0&
IRoleEntityClaimRepository "
RoleEntityClaims# 3
{4 5
get6 9
;9 :
}; <
IRoleRepository 
Roles 
{ 
get  #
;# $
}% & 
IUserClaimRepository 

UserClaims '
{( )
get* -
;- .
}/ 0&
IUserEntityClaimRepository "
UserEntityClaims# 3
{4 5
get6 9
;9 :
}; <
IUserRepository 
Users 
{ 
get  #
;# $
}% &
IUserRoleRepository 
	UserRoles %
{& '
get( +
;+ ,
}- .
IUserUtilRepository 
	UserUtils %
{& '
get( +
;+ ,
}- .
} 
} ∆

çC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\ClaimModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class #
ClaimModelConfiguration (
<( )
T) *
>* +
:, -"
BaseModelConfiguration. D
<D E
TE F
,F G
intH K
>K L
whereM R
TS T
:U V
ClaimW \
{ 
public		 
override		 
void		 
	Configure		 &
(		& '
EntityTypeBuilder		' 8
<		8 9
T		9 :
>		: ;
builder		< C
)		C D
{

 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
CustomClaim$ /
)/ 0
. 

IsRequired 
( 
) 
; 
} 	
} 
} õ
ôC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\ClientApplicationModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class /
#ClientApplicationModelConfiguration 4
<4 5
T5 6
>6 7
:8 9"
BaseModelConfiguration: P
<P Q
TQ R
,R S
intT W
>W X
whereY ^
T_ `
:a b
ClientApplicationc t
{ 
public		 
override		 
void		 
	Configure		 &
(		& '
EntityTypeBuilder		' 8
<		8 9
T		9 :
>		: ;
builder		< C
)		C D
{

 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
u 
=> !
u" #
.# $!
ClientApplicationName$ 9
)9 :
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
builder 
. 
Property 
( 
u 
=> !
u" #
.# $!
ClientApplicationCode$ 9
)9 :
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num 
)  
;  !
builder 
. 
Property 
( 
u 
=> !
u" #
.# $%
ClientApplicationPassword$ =
)= >
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
} 	
} 
} •
ùC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\ClientApplicationUtilModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class 3
'ClientApplicationUtilModelConfiguration 8
<8 9
T9 :
>: ;
:< ="
BaseModelConfiguration> T
<T U
TU V
,V W
intX [
>[ \
where] b
Tc d
:e f!
ClientApplicationUtilg |
{ 
public		 
override		 
void		 
	Configure		 &
(		& '
EntityTypeBuilder		' 8
<		8 9
T		9 :
>		: ;
builder		< C
)		C D
{

 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
u 
=> !
u" #
.# $
SpecialValue$ 0
)0 1
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num !
)! "
;" #
builder 
. 
Property 
( 
u 
=> !
u" #
.# $
ClientApplicationId$ 7
)7 8
. 

IsRequired 
( 
) 
; 
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
ClientApplication 0
)0 1
. 
WithOne 
( 
c 
=> 
( 
T  
)  !
c! "
." #!
ClientApplicationUtil# 8
)8 9
. 
HasForeignKey 
< !
ClientApplicationUtil 4
>4 5
(5 6
r6 7
=>8 :
r; <
.< =
ClientApplicationId= P
)P Q
. 
HasPrincipalKey  
<  !
ClientApplication! 2
>2 3
(3 4
c4 5
=>5 7
c7 8
.8 9
Id9 ;
); <
;< =
} 	
} 
} ﬂ
ëC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\RoleClaimModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class '
RoleClaimModelConfiguration ,
<, -
T- .
>. /
:0 1"
BaseModelConfiguration2 H
<H I
TI J
,J K
intL O
>O P
whereQ V
TW X
:Y Z
	RoleClaim[ d
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
RoleId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
ClaimId$ +
)+ ,
. 

IsRequired 
( 
) 
; 
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
Role #
)# $
. 
WithMany 
( 
c 
=> 
(  
IEnumerable  +
<+ ,
T, -
>- .
). /
c/ 0
.0 1

RoleClaims1 ;
); <
. 
HasForeignKey 
( 
r  
=>! #
r$ %
.% &
RoleId& ,
), -
;- .
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
Claim $
)$ %
. 
WithMany 
( 
c 
=> 
(  
IEnumerable  +
<+ ,
T, -
>- .
). /
c/ 0
.0 1

RoleClaims1 ;
); <
. 
HasForeignKey 
( 
r  
=>! #
r$ %
.% &
ClaimId& -
)- .
;. /
} 	
} 
}   Ñ
óC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\RoleEntityClaimModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class -
!RoleEntityClaimModelConfiguration 2
<2 3
T3 4
>4 5
:6 7"
BaseModelConfiguration8 N
<N O
TO P
,P Q
intR U
>U V
whereW \
T] ^
:_ `
RoleEntityClaima p
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
RoleId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Entity$ *
)* +
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanSelect$ -
)- .
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanCreate$ -
)- .
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanUpdate$ -
)- .
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanDelete$ -
)- .
. 

IsRequired 
( 
) 
; 
builder!! 
."" 
HasOne"" 
("" 
r"" 
=>"" 
r"" 
."" 
Role"" #
)""# $
.## 
WithMany## 
(## 
c## 
=>## 
(##  
IEnumerable##  +
<##+ ,
T##, -
>##- .
)##. /
c##/ 0
.##0 1
RoleEntityClaims##1 A
)##A B
.$$ 
HasForeignKey$$ 
($$ 
r$$  
=>$$! #
r$$$ %
.$$% &
RoleId$$& ,
)$$, -
;$$- .
}&& 	
}'' 
}(( Ø
åC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\RoleModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class "
RoleModelConfiguration '
<' (
T( )
>) *
:+ ,"
BaseModelConfiguration- C
<C D
TD E
,E F
intG J
>J K
whereL Q
TR S
:T U
RoleV Z
{ 
public		 
override		 
void		 
	Configure		 &
(		& '
EntityTypeBuilder		' 8
<		8 9
T		9 :
>		: ;
builder		< C
)		C D
{

 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
RoleName$ ,
), -
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Description$ /
)/ 0
. 
HasMaxLength 
( 
$num !
)! "
;" #
} 	
} 
} ﬂ
ëC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\UserClaimModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class '
UserClaimModelConfiguration ,
<, -
T- .
>. /
:0 1"
BaseModelConfiguration2 H
<H I
TI J
,J K
intL O
>O P
whereQ V
TW X
:Y Z
	UserClaim[ d
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
UserId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
ClaimId$ +
)+ ,
. 

IsRequired 
( 
) 
; 
builder 
. 
HasOne 
( 
r 
=> 
r 
.  
User  $
)$ %
. 
WithMany 
( 
c 
=> 
(  !
IEnumerable! ,
<, -
T- .
>. /
)/ 0
c0 1
.1 2

UserClaims2 <
)< =
. 
HasForeignKey 
(  
r  !
=>" $
r% &
.& '
UserId' -
)- .
;. /
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
Claim $
)$ %
. 
WithMany 
( 
c 
=> 
(  
IEnumerable  +
<+ ,
T, -
>- .
). /
c/ 0
.0 1

UserClaims1 ;
); <
. 
HasForeignKey 
( 
r  
=>! #
r$ %
.% &
ClaimId& -
)- .
;. /
} 	
} 
}   Ñ
óC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\UserEntityClaimModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class -
!UserEntityClaimModelConfiguration 2
<2 3
T3 4
>4 5
:6 7"
BaseModelConfiguration8 N
<N O
TO P
,P Q
intR U
>U V
whereW \
T] ^
:_ `
UserEntityClaima p
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
UserId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Entity$ *
)* +
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanSelect$ -
)- .
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanCreate$ -
)- .
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanUpdate$ -
)- .
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	CanDelete$ -
)- .
. 

IsRequired 
( 
) 
; 
builder!! 
."" 
HasOne"" 
("" 
r"" 
=>"" 
r"" 
."" 
User"" #
)""# $
.## 
WithMany## 
(## 
c## 
=>## 
(##  
IEnumerable##  +
<##+ ,
T##, -
>##- .
)##. /
c##/ 0
.##0 1
UserEntityClaims##1 A
)##A B
.$$ 
HasForeignKey$$ 
($$ 
r$$  
=>$$! #
r$$$ %
.$$% &
UserId$$& ,
)$$, -
;$$- .
}&& 	
}'' 
}(( Å
åC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\UserModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public		 

class		 "
UserModelConfiguration		 '
<		' (
T		( )
>		) *
:		+ ,"
BaseModelConfiguration		- C
<		C D
T		D E
,		E F
int		G J
>		J K
where		L Q
T		R S
:		T U
User		V Z
{

 
public 
override 
void 
	Configure &
(& '
EntityTypeBuilder' 8
<8 9
T9 :
>: ;
builder< C
)C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
UserName$ ,
), -
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num  
)  !
;! "
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Password$ ,
), -
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num !
)! "
;" #
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Email$ )
)) *
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num !
)! "
;" #
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
EmailConfirmed$ 2
)2 3
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
EmailConfirmCode$ 4
)4 5
. 

IsRequired 
( 
) 
.   
HasMaxLength   
(   
$num   
)    
.!! 
HasDefaultValue!!  
(!!  !
new!!! $
Random!!% +
(!!+ ,
)!!, -
.!!- .
Next!!. 2
(!!2 3
$num!!3 9
,!!9 :
$num!!; A
)!!A B
)!!B C
;!!C D
builder## 
.## 
Property## 
(## 
p## 
=>## !
p##" #
.### $
AccessFailedCount##$ 5
)##5 6
.$$ 

IsRequired$$ 
($$ 
)$$ 
.%% 
HasDefaultValue%%  
(%%  !
$num%%! "
)%%" #
;%%# $
builder'' 
.'' 
Property'' 
('' 
p'' 
=>'' !
p''" #
.''# $
Lockout''$ +
)''+ ,
.(( 

IsRequired(( 
((( 
)(( 
;(( 
builder** 
.** 
Property** 
(** 
p** 
=>** !
p**" #
.**# $
LockoutEndDateTime**$ 6
)**6 7
.++ 

IsRequired++ 
(++ 
false++ !
)++! "
.,, 
HasMaxLength,, 
(,, 
$num,, !
),,! "
;,," #
}-- 	
}.. 
}// ◊
êC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\UserRoleModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class &
UserRoleModelConfiguration +
<+ ,
T, -
>- .
:/ 0"
BaseModelConfiguration1 G
<G H
TH I
,I J
intK N
>N O
whereP U
TV W
:X Y
UserRoleZ b
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
UserId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
RoleId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
User #
)# $
. 
WithMany 
( 
c 
=> 
(  
IEnumerable  +
<+ ,
T, -
>- .
). /
c/ 0
.0 1
	UserRoles1 :
): ;
. 
HasForeignKey 
( 
r  
=>! #
r$ %
.% &
UserId& ,
), -
;- .
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
Role #
)# $
. 
WithMany 
( 
c 
=> 
(  
IEnumerable  +
<+ ,
T, -
>- .
). /
c/ 0
.0 1
	UserRoles1 :
): ;
. 
HasForeignKey 
( 
r  
=>! #
r$ %
.% &
RoleId& ,
), -
;- .
} 	
} 
}   ∞
êC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\ModelConfigurations\UserUtilModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
ModelConfigurations9 L
{ 
public 

class &
UserUtilModelConfiguration +
<+ ,
T, -
>- .
:/ 0"
BaseModelConfiguration1 G
<G H
TH I
,I J
intK N
>N O
whereP U
TV W
:X Y
UserUtilZ b
{ 
public		 
override		 
void		 
	Configure		 &
(		& '
EntityTypeBuilder		' 8
<		8 9
T		9 :
>		: ;
builder		< C
)		C D
{

 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
u 
=> !
u" #
.# $
SpecialValue$ 0
)0 1
. 

IsRequired 
( 
) 
. 
HasMaxLength 
( 
$num !
)! "
;" #
builder 
. 
Property 
( 
u 
=> !
u" #
.# $
UserId$ *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
HasOne 
( 
r 
=> 
r 
. 
User #
)# $
. 
WithOne 
( 
c 
=> 
( 
T  
)  !
c! "
." #
UserUtil# +
)+ ,
. 
HasForeignKey 
< 
UserUtil '
>' (
(( )
r) *
=>+ -
r. /
./ 0
UserId0 6
)6 7
. 
HasPrincipalKey  
<  !
User! %
>% &
(& '
c' (
=>( *
c* +
.+ ,
Id, .
). /
;/ 0
} 	
} 
} Ò
~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\ClaimRepository.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Data		4 8
.		8 9
Repositories		9 E
{

 
public 

class 
ClaimRepository  
:! "
BaseRepository# 1
<1 2
Claim2 7
,7 8
int9 <
>< =
,= >
IClaimRepository? O
{ 
public 
ClaimRepository 
( 
	DbContext (
	dbContext) 2
)2 3
:4 5
base6 :
(: ;
	dbContext; D
)D E
{ 	
} 	
public 
async 
Task 
< 
Claim 
>  !
GetByCustomClaimAsync! 6
(6 7
string7 =
customClaim> I
)I J
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
CustomClaim$ /
==0 2
customClaim3 >
)> ?
.? @
FirstOrDefaultAsync@ S
(S T
)T U
;U V
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Claim& +
>+ ,
>, -
GetAllAsync. 9
(9 :
int: =
	pageIndex> G
,G H
intI L
pageSizeM U
)U V
{ 	
return 
await 
( 
await !
GetAllWithPagingAsync  5
(5 6
paging6 <
:< =
new> A
PagingB H
(H I
	pageIndexI R
,R S
pageSizeT \
)\ ]
)] ^
)^ _
._ `
ToCustomList` l
(l m
)m n
;n o
} 	
} 
} €
äC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\ClientApplicationRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

class '
ClientApplicationRepository ,
:- .
BaseRepository/ =
<= >
ClientApplication> O
,O P
intQ T
>T U
,U V(
IClientApplicationRepositoryW s
{		 
public

 '
ClientApplicationRepository

 *
(

* +
	DbContext

+ 4
	dbContext

5 >
)

> ?
:

@ A
base

B F
(

F G
	dbContext

G P
)

P Q
{ 	
} 	
public 
async 
Task 
< 
ClientApplication +
>+ ,%
GetByCodeAndPasswordAsync- F
(F G
stringG M
codeN R
,R S
stringT Z
password[ c
)c d
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $!
ClientApplicationCode$ 9
==: <
code= A
&&B D
pE F
.F G%
ClientApplicationPasswordG `
==a c
passwordd l
)l m
. 
FirstOrDefaultAsync $
($ %
)% &
;& '
} 	
public 
async 
Task 
< 
ClientApplication +
>+ ,
GetByCodeAsync- ;
(; <
string< B
codeC G
)G H
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $!
ClientApplicationCode$ 9
==: <
code= A
)A B
.B C
FirstOrDefaultAsyncC V
(V W
)W X
;X Y
} 	
public 
async 
Task 
< 
ClientApplication +
>+ ,
GetByNameAsync- ;
(; <
string< B
nameC G
)G H
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $!
ClientApplicationName$ 9
==: <
name= A
)A B
.B C
FirstOrDefaultAsyncC V
(V W
)W X
;X Y
} 	
} 
} ä
éC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\ClientApplicationUtilRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

class +
ClientApplicationUtilRepository 0
:1 2
BaseRepository3 A
<A B!
ClientApplicationUtilB W
,W X
intY \
>\ ]
,] ^,
 IClientApplicationUtilRepository_ 
{		 
public

 +
ClientApplicationUtilRepository

 .
(

. /
	DbContext

/ 8
	dbContext

9 B
)

B C
:

D E
base

F J
(

J K
	dbContext

K T
)

T U
{ 	
} 	
public 
async 
Task 
< !
ClientApplicationUtil /
>/ 0)
GetByClientApplicationIdAsync1 N
(N O
intO R
clientApplicationIdS f
)f g
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
ClientApplicationId$ 7
==8 :
clientApplicationId; N
)N O
.O P
FirstOrDefaultAsyncP c
(c d
)d e
;e f
} 	
} 
} ß
C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public		 

	interface		 
IClaimRepository		 %
:		& '
IRepository		( 3
<		3 4
Claim		4 9
,		9 :
int		; >
>		> ?
{

 
Task 
< 
Claim 
> !
GetByCustomClaimAsync )
() *
string* 0
customClaim1 <
)< =
;= >
Task 
< 
ICustomList 
< 
Claim 
> 
>  
GetAllAsync! ,
(, -
int- 0
	pageIndex1 :
,: ;
int< ?
pageSize@ H
)H I
;I J
} 
} Ï	
ãC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IClientApplicationRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

	interface (
IClientApplicationRepository 1
:2 3
IRepository4 ?
<? @
ClientApplication@ Q
,Q R
intS V
>V W
{ 
Task		 
<		 
ClientApplication		 
>		 
GetByNameAsync		  .
(		. /
string		/ 5
name		6 :
)		: ;
;		; <
Task

 
<

 
ClientApplication

 
>

 
GetByCodeAsync

  .
(

. /
string

/ 5
code

6 :
)

: ;
;

; <
Task 
< 
ClientApplication 
> %
GetByCodeAndPasswordAsync  9
(9 :
string: @
codeA E
,E F
stringG M
passwordN V
)V W
;W X
} 
} ◊
èC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IClientApplicationUtilRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

	interface ,
 IClientApplicationUtilRepository 5
:6 7
IRepository8 C
<C D!
ClientApplicationUtilD Y
,Y Z
int[ ^
>^ _
{ 
Task		 
<		 !
ClientApplicationUtil		 "
>		" #)
GetByClientApplicationIdAsync		$ A
(		A B
int		B E
clientApplicationId		F Y
)		Y Z
;		Z [
}

 
} ï
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IRoleClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public		 

	interface		  
IRoleClaimRepository		 )
:		* +
IRepository		, 7
<		7 8
	RoleClaim		8 A
,		A B
int		C F
>		F G
{

 
Task 
< 
	RoleClaim 
> &
GetByRoleIdAndClaimIdAsync 2
(2 3
int3 6
roleId7 =
,= >
int? B
claimIdC J
)J K
;K L
Task 
< 
ICustomList 
< 
Claim 
> 
>  "
GetClaimsByRoleIdAsync! 7
(7 8
int8 ;
roleId< B
)B C
;C D
Task 
< 
ICustomList 
< 
Role 
> 
> "
GetRolesByClaimIdAsync  6
(6 7
int7 :
claimId; B
)B C
;C D
Task 
< 
ICustomList 
< 
	RoleClaim "
>" #
># $+
RolesAreAuthorizedForClaimAsync% D
(D E
IEnumerableE P
<P Q
RoleQ U
>U V
rolesW \
,\ ]
int^ a
claimIdb i
)i j
;j k
} 
} Ö
âC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IRoleEntityClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{		 
public

 

	interface

 &
IRoleEntityClaimRepository

 /
:

0 1
IRepository

2 =
<

= >
RoleEntityClaim

> M
,

M N
int

O R
>

R S
{ 
Task 
< 
RoleEntityClaim 
> %
GetByRoleIdAndEntityAsync 7
(7 8
int8 ;
roleId< B
,B C
stringD J
entityK Q
)Q R
;R S
Task 
< 
ICustomList 
< 
RoleEntityClaim (
>( )
>) *1
%RolesAreAuthorizedForEntityClaimAsync+ P
(P Q
IEnumerableQ \
<\ ]
Role] a
>a b
rolesc h
,h i
stringj p
entityq w
,w x
Crudy }
crud	~ Ç
)
Ç É
;
É Ñ
Task 
< 
ICustomList 
< 
RoleEntityClaim (
>( )
>) *
GetAllByEntityAsync+ >
(> ?
string? E
entityF L
)L M
;M N
Task 
< 
ICustomList 
< 
RoleEntityClaim (
>( )
>) *
GetAllByRoleIdAsync+ >
(> ?
int? B
roleIdC I
)I J
;J K
} 
} ∂
~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IRoleRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

	interface 
IRoleRepository $
:% &
IRepository' 2
<2 3
Role3 7
,7 8
int9 <
>< =
{		 
Task

 
<

 
Role

 
>

 
GetByNameAsync

 !
(

! "
string

" (
name

) -
)

- .
;

. /
Task 
< 
ICustomList 
< 
Role 
> 
> 
GetAllAsync  +
(+ ,
), -
;- .
} 
} ‹
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IUserClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public		 

	interface		  
IUserClaimRepository		 )
:		* +
IRepository		, 7
<		7 8
	UserClaim		8 A
,		A B
int		C F
>		F G
{

 
Task 
< 
	UserClaim 
> &
GetByUserIdAndClaimIdAsync 2
(2 3
int3 6
userId7 =
,= >
int? B
claimIdC J
)J K
;K L
Task 
< 
ICustomList 
< 
Claim 
> 
>  "
GetClaimsByUserIdAsync! 7
(7 8
int8 ;
userId< B
)B C
;C D
Task 
< 
ICustomList 
< 
User 
> 
> "
GetUsersByClaimIdAsync  6
(6 7
int7 :
claimId; B
)B C
;C D
Task 
< 
ICustomList 
< 
	UserClaim "
>" #
># $)
UserIsAuthorizedForClaimAsync% B
(B C
intC F
userIdG M
,M N
intO R
claimIdS Z
)Z [
;[ \
} 
} «
âC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IUserEntityClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public		 

	interface		 &
IUserEntityClaimRepository		 /
:		0 1
IRepository		2 =
<		= >
UserEntityClaim		> M
,		M N
int		O R
>		R S
{

 
Task 
< 
UserEntityClaim 
> %
GetByUserIdAndEntityAsync 7
(7 8
int8 ;
userId< B
,B C
stringD J
entityK Q
)Q R
;R S
Task 
< 
ICustomList 
< 
UserEntityClaim (
>( )
>) */
#UserIsAuthorizedForEntityClaimAsync+ N
(N O
intO R
userIdS Y
,Y Z
string[ a
entityb h
,h i
Crudj n
crudo s
)s t
;t u
Task 
< 
ICustomList 
< 
UserEntityClaim (
>( )
>) *
GetAllByEntityAsync+ >
(> ?
string? E
entityF L
)L M
;M N
Task 
< 
ICustomList 
< 
UserEntityClaim (
>( )
>) *
GetAllByUserIdAsync+ >
(> ?
int? B
userIdC I
)I J
;J K
} 
} Ó

~C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IUserRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

	interface 
IUserRepository $
:% &
IRepository' 2
<2 3
User3 7
,7 8
int9 <
>< =
{		 
Task

 
<

 
User

 
>

 
GetByUserNameAsync

 %
(

% &
string

& ,
userName

- 5
)

5 6
;

6 7
Task 
< 
User 
> 
GetByEmailAsync "
(" #
string# )
email* /
)/ 0
;0 1
Task 
< 
User 
> )
GetByUserNameAndPasswordAsync 0
(0 1
string1 7
userName8 @
,@ A
stringB H
passwordI Q
)Q R
;R S
Task 
< 
ICustomList 
< 
User 
> 
> 
GetAllAsync  +
(+ ,
), -
;- .
} 
} ¢

ÇC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IUserRoleRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

	interface 
IUserRoleRepository (
:) *
IRepository+ 6
<6 7
UserRole7 ?
,? @
intA D
>D E
{		 
Task

 
<

 
UserRole

 
>

 %
GetByUserIdAndRoleIdAsync

 0
(

0 1
int

1 4
userId

5 ;
,

; <
int

= @
roleId

A G
)

G H
;

H I
Task 
< 
ICustomList 
< 
User 
> 
> !
GetUsersByRoleIdAsync  5
(5 6
int6 9
roleId: @
)@ A
;A B
Task 
< 
ICustomList 
< 
Role 
> 
> !
GetRolesByUserIdAsync  5
(5 6
int6 9
userId: @
)@ A
;A B
} 
} â
ÇC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\IUserUtilRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

	interface 
IUserUtilRepository (
:) *
IRepository+ 6
<6 7
UserUtil7 ?
,? @
intA D
>D E
{ 
Task		 
<		 
UserUtil		 
>		 
GetByUserIdAsync		 '
(		' (
int		( +
userId		, 2
)		2 3
;		3 4
}

 
} ¸&
ÇC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\RoleClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

class 
RoleClaimRepository $
:% &
BaseRepository' 5
<5 6
	RoleClaim6 ?
,? @
intA D
>D E
,E F 
IRoleClaimRepositoryG [
{ 
public 
RoleClaimRepository "
(" #
	DbContext# ,
	dbContext- 6
)6 7
:8 9
base: >
(> ?
	dbContext? H
)H I
{ 	
} 	
public 
async 
Task 
< 
	RoleClaim #
># $&
GetByRoleIdAndClaimIdAsync% ?
(? @
int@ C
roleIdD J
,J K
intL O
claimIdP W
)W X
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
RoleId$ *
==+ -
roleId. 4
&&5 7
p8 9
.9 :
ClaimId: A
==B D
claimIdE L
)L M
.M N
FirstOrDefaultAsyncN a
(a b
)b c
;c d
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Claim& +
>+ ,
>, -"
GetClaimsByRoleIdAsync. D
(D E
intE H
roleIdI O
)O P
{ 	
return 
await 
GetAll 
(  
p  !
=>" $
p% &
.& '
RoleId' -
==. 0
roleId1 7
)7 8
.8 9
IncludeMultiple9 H
(H I
pI J
=>K M
pN O
.O P
ClaimP U
)U V
.V W
SelectW ]
(] ^
p^ _
=>` b
pc d
.d e
Claime j
)j k
. 
ToCustomList 
( 
) 
;  
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Role& *
>* +
>+ ,"
GetRolesByClaimIdAsync- C
(C D
intD G
claimIdH O
)O P
{ 	
return   
await   
GetAll   
(    
p    !
=>  " $
p  % &
.  & '
ClaimId  ' .
==  / 1
claimId  2 9
)  9 :
.  : ;
IncludeMultiple  ; J
(  J K
p  K L
=>  M O
p  P Q
.  Q R
Role  R V
)  V W
.  W X
Select  X ^
(  ^ _
p  _ `
=>  a c
p  d e
.  e f
Role  f j
)  j k
.!! 
ToCustomList!! 
(!! 
)!! 
;!!  
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
ICustomList$$ %
<$$% &
	RoleClaim$$& /
>$$/ 0
>$$0 1+
RolesAreAuthorizedForClaimAsync$$2 Q
($$Q R
IEnumerable$$R ]
<$$] ^
Role$$^ b
>$$b c
roles$$d i
,$$i j
int$$k n
claimId$$o v
)$$v w
{%% 	
var&& 
	predicate&& 
=&& 
PredicateBuilder&& ,
.&&, -
New&&- 0
<&&0 1
	RoleClaim&&1 :
>&&: ;
(&&; <
)&&< =
;&&= >
	predicate'' 
='' 
roles'' 
.'' 
	Aggregate'' '
(''' (
	predicate''( 1
,''1 2
(''3 4
current''4 ;
,''; <
role''= A
)''A B
=>''C E
current''F M
.''M N
Or''N P
(''P Q
p''Q R
=>''S U
p''V W
.''W X
RoleId''X ^
==''_ a
role''b f
.''f g
Id''g i
)''i j
)''j k
;''k l
	predicate(( 
=(( 
	predicate(( !
.((! "
And((" %
(((% &
p((& '
=>((( *
p((+ ,
.((, -
ClaimId((- 4
==((5 7
claimId((8 ?
)((? @
;((@ A
return** 
await** 
GetAll** 
(**  
	predicate**  )
:**) *
	predicate**+ 4
)**4 5
.**5 6
ToCustomList**6 B
(**B C
)**C D
;**D E
}++ 	
},, 
}-- Ú4
àC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\RoleEntityClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

class %
RoleEntityClaimRepository *
:+ ,
BaseRepository- ;
<; <
RoleEntityClaim< K
,K L
intM P
>P Q
,Q R&
IRoleEntityClaimRepositoryS m
{ 
public %
RoleEntityClaimRepository (
(( )
	DbContext) 2
	dbContext3 <
)< =
:> ?
base@ D
(D E
	dbContextE N
)N O
{ 	
} 	
public 
async 
Task 
< 
RoleEntityClaim )
>) *%
GetByRoleIdAndEntityAsync+ D
(D E
intE H
roleIdI O
,O P
stringQ W
entityX ^
)^ _
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
RoleId$ *
==+ -
roleId. 4
&&5 7
p8 9
.9 :
Entity: @
==A C
entityD J
)J K
.K L
FirstOrDefaultAsyncL _
(_ `
)` a
;a b
} 	
public 
async 
Task 
< 
ICustomList %
<% &
RoleEntityClaim& 5
>5 6
>6 71
%RolesAreAuthorizedForEntityClaimAsync8 ]
(] ^
IEnumerable^ i
<i j
Rolej n
>n o
rolesp u
,u v
stringw }
entity	~ Ñ
,
Ñ Ö
Crud
Ü ä
crud
ã è
)
è ê
{ 	
var 
	predicate 
= 
PredicateBuilder ,
., -
New- 0
<0 1
RoleEntityClaim1 @
>@ A
(A B
)B C
;C D
	predicate 
= 
roles 
. 
	Aggregate '
(' (
	predicate( 1
,1 2
(3 4
current4 ;
,; <
role= A
)A B
=>C E
currentF M
.M N
OrN P
(P Q
pQ R
=>S U
pV W
.W X
RoleIdX ^
==_ a
roleb f
.f g
Idg i
)i j
)j k
;k l
	predicate 
= 
	predicate !
.! "
And" %
(% &
p& '
=>( *
p+ ,
., -
Entity- 3
==4 6
entity7 =
)= >
;> ?#
PredicateBuilderForCrud #
(# $
ref$ '
	predicate( 1
,1 2
crud3 7
)7 8
;8 9
return!! 
await!! 
GetAll!! 
(!!  
	predicate!!  )
:!!) *
	predicate!!+ 4
)!!4 5
.!!5 6
ToCustomList!!6 B
(!!B C
)!!C D
;!!D E
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
ICustomList$$ %
<$$% &
RoleEntityClaim$$& 5
>$$5 6
>$$6 7
GetAllByEntityAsync$$8 K
($$K L
string$$L R
entity$$S Y
)$$Y Z
{%% 	
return&& 
await&& 
GetAll&& 
(&&  
p&&  !
=>&&" $
p&&% &
.&&& '
Entity&&' -
==&&. 0
entity&&1 7
)&&7 8
.&&8 9
ToCustomList&&9 E
(&&E F
)&&F G
;&&G H
}'' 	
public)) 
async)) 
Task)) 
<)) 
ICustomList)) %
<))% &
RoleEntityClaim))& 5
>))5 6
>))6 7
GetAllByRoleIdAsync))8 K
())K L
int))L O
roleId))P V
)))V W
{** 	
return++ 
await++ 
GetAll++ 
(++  
p++  !
=>++" $
p++% &
.++& '
RoleId++' -
==++. 0
roleId++1 7
)++7 8
.++8 9
ToCustomList++9 E
(++E F
)++F G
;++G H
},, 	
private.. 
static.. 
void.. #
PredicateBuilderForCrud.. 3
(..3 4
ref..4 7
ExpressionStarter..8 I
<..I J
RoleEntityClaim..J Y
>..Y Z
	predicate..[ d
,..d e
Crud..f j
crud..k o
)..o p
{// 	
switch00 
(00 
crud00 
)00 
{11 
case22 
Crud22 
.22 
Create22  
:22  !
	predicate33 
=33 
	predicate33  )
.33) *
And33* -
(33- .
p33. /
=>330 2
p333 4
.334 5
	CanCreate335 >
)33> ?
;33? @
break44 
;44 
case55 
Crud55 
.55 
Update55  
:55  !
	predicate66 
=66 
	predicate66  )
.66) *
And66* -
(66- .
p66. /
=>660 2
p663 4
.664 5
	CanUpdate665 >
)66> ?
;66? @
break77 
;77 
case88 
Crud88 
.88 
Delete88  
:88  !
	predicate99 
=99 
	predicate99  )
.99) *
And99* -
(99- .
p99. /
=>990 2
p993 4
.994 5
	CanDelete995 >
)99> ?
;99? @
break:: 
;:: 
case;; 
Crud;; 
.;; 
Select;;  
:;;  !
	predicate<< 
=<< 
	predicate<<  )
.<<) *
And<<* -
(<<- .
p<<. /
=><<0 2
p<<3 4
.<<4 5
	CanSelect<<5 >
)<<> ?
;<<? @
break== 
;== 
default>> 
:>> 
throw?? 
new?? '
ArgumentOutOfRangeException?? 9
(??9 :
nameof??: @
(??@ A
crud??A E
)??E F
,??F G
crud??H L
,??L M
null??N R
)??R S
;??S T
}@@ 
}AA 	
}BB 
}CC í
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\RoleRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{		 
public

 

class

 
RoleRepository

 
:

  !
BaseRepository

" 0
<

0 1
Role

1 5
,

5 6
int

7 :
>

: ;
,

; <
IRoleRepository

= L
{ 
public 
RoleRepository 
( 
	DbContext '
	dbContext( 1
)1 2
:3 4
base5 9
(9 :
	dbContext: C
)C D
{ 	
} 	
public 
async 
Task 
< 
Role 
> 
GetByNameAsync  .
(. /
string/ 5
name6 :
): ;
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
RoleName$ ,
==- /
name0 4
)4 5
.5 6
FirstOrDefaultAsync6 I
(I J
)J K
;K L
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Role& *
>* +
>+ ,
GetAllAsync- 8
(8 9
)9 :
{ 	
return 
await 
GetAll 
(  
)  !
.! "
ToCustomList" .
(. /
)/ 0
;0 1
} 	
} 
} ë 
ÇC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\UserClaimRepository.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Data		4 8
.		8 9
Repositories		9 E
{

 
public 

class 
UserClaimRepository $
:% &
BaseRepository' 5
<5 6
	UserClaim6 ?
,? @
intA D
>D E
,E F 
IUserClaimRepositoryG [
{ 
public 
UserClaimRepository "
(" #
	DbContext# ,
	dbContext- 6
)6 7
:8 9
base: >
(> ?
	dbContext? H
)H I
{ 	
} 	
public 
async 
Task 
< 
	UserClaim #
># $&
GetByUserIdAndClaimIdAsync% ?
(? @
int@ C
userIdD J
,J K
intL O
claimIdP W
)W X
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
UserId$ *
==+ -
userId. 4
&&5 7
p8 9
.9 :
ClaimId: A
==B D
claimIdE L
)L M
.M N
FirstOrDefaultAsyncN a
(a b
)b c
;c d
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Claim& +
>+ ,
>, -"
GetClaimsByUserIdAsync. D
(D E
intE H
userIdI O
)O P
{ 	
return 
await 
GetAll 
(  
p  !
=>" $
p% &
.& '
UserId' -
==. 0
userId1 7
)7 8
.8 9
IncludeMultiple9 H
(H I
pI J
=>K M
pN O
.O P
ClaimP U
)U V
.V W
SelectW ]
(] ^
p^ _
=>` b
pc d
.d e
Claime j
)j k
. 
ToCustomList 
( 
) 
;  
} 	
public 
async 
Task 
< 
ICustomList %
<% &
User& *
>* +
>+ ,"
GetUsersByClaimIdAsync- C
(C D
intD G
claimIdH O
)O P
{ 	
return 
await 
GetAll 
(  
p  !
=>" $
p% &
.& '
ClaimId' .
==/ 1
claimId2 9
)9 :
.: ;
IncludeMultiple; J
(J K
pK L
=>M O
pP Q
.Q R
UserR V
)V W
.W X
SelectX ^
(^ _
p_ `
=>a c
pd e
.e f
Userf j
)j k
. 
ToCustomList 
( 
) 
;  
}   	
public"" 
async"" 
Task"" 
<"" 
ICustomList"" %
<""% &
	UserClaim""& /
>""/ 0
>""0 1)
UserIsAuthorizedForClaimAsync""2 O
(""O P
int""P S
userId""T Z
,""Z [
int""\ _
claimId""` g
)""g h
{## 	
return$$ 
await$$ 
GetAll$$ 
($$  
p$$  !
=>$$" $
p$$% &
.$$& '
UserId$$' -
==$$. 0
userId$$1 7
&&$$8 :
p$$; <
.$$< =
ClaimId$$= D
==$$E G
claimId$$H O
)$$O P
.$$P Q
ToCustomList$$Q ]
($$] ^
)$$^ _
;$$_ `
}%% 	
}&& 
}'' Ñ3
àC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\UserEntityClaimRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

class %
UserEntityClaimRepository *
:+ ,
BaseRepository- ;
<; <
UserEntityClaim< K
,K L
intM P
>P Q
,Q R&
IUserEntityClaimRepositoryS m
{ 
public %
UserEntityClaimRepository (
(( )
	DbContext) 2
	dbContext3 <
)< =
:> ?
base@ D
(D E
	dbContextE N
)N O
{ 	
} 	
public 
async 
Task 
< 
UserEntityClaim )
>) *%
GetByUserIdAndEntityAsync+ D
(D E
intE H
userIdI O
,O P
stringQ W
entityX ^
)^ _
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
UserId$ *
==+ -
userId. 4
&&5 7
p8 9
.9 :
Entity: @
==A C
entityD J
)J K
.K L
FirstOrDefaultAsyncL _
(_ `
)` a
;a b
} 	
public 
async 
Task 
< 
ICustomList %
<% &
UserEntityClaim& 5
>5 6
>6 7/
#UserIsAuthorizedForEntityClaimAsync8 [
([ \
int\ _
userId` f
,f g
stringh n
entityo u
,u v
Crudw {
crud	| Ä
)
Ä Å
{ 	
var 
	predicate 
= 
PredicateBuilder ,
., -
New- 0
<0 1
UserEntityClaim1 @
>@ A
(A B
)B C
;C D
	predicate 
= 
	predicate !
.! "
And" %
(% &
p& '
=>( *
p+ ,
., -
UserId- 3
==4 6
userId7 =
)= >
;> ?
	predicate 
= 
	predicate !
.! "
And" %
(% &
p& '
=>( *
p+ ,
., -
Entity- 3
==4 6
entity7 =
)= >
;> ?#
PredicateBuilderForCrud #
(# $
ref$ '
	predicate( 1
,1 2
crud3 7
)7 8
;8 9
return!! 
await!! 
GetAll!! 
(!!  
	predicate!!  )
:!!) *
	predicate!!+ 4
)!!4 5
.!!5 6
ToCustomList!!6 B
(!!B C
)!!C D
;!!D E
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
ICustomList$$ %
<$$% &
UserEntityClaim$$& 5
>$$5 6
>$$6 7
GetAllByEntityAsync$$8 K
($$K L
string$$L R
entity$$S Y
)$$Y Z
{%% 	
return&& 
await&& 
GetAll&& 
(&&  
	predicate&&  )
:&&) *
p&&+ ,
=>&&- /
p&&0 1
.&&1 2
Entity&&2 8
==&&9 ;
entity&&< B
)&&B C
.&&C D
ToCustomList&&D P
(&&P Q
)&&Q R
;&&R S
}'' 	
public)) 
async)) 
Task)) 
<)) 
ICustomList)) %
<))% &
UserEntityClaim))& 5
>))5 6
>))6 7
GetAllByUserIdAsync))8 K
())K L
int))L O
userId))P V
)))V W
{** 	
return++ 
await++ 
GetAll++ 
(++  
	predicate++  )
:++) *
p+++ ,
=>++- /
p++0 1
.++1 2
UserId++2 8
==++9 ;
userId++< B
)++B C
.++C D
ToCustomList++D P
(++P Q
)++Q R
;++R S
},, 	
private.. 
static.. 
void.. #
PredicateBuilderForCrud.. 3
(..3 4
ref..4 7
ExpressionStarter..8 I
<..I J
UserEntityClaim..J Y
>..Y Z
	predicate..[ d
,..d e
Crud..f j
crud..k o
)..o p
{// 	
switch00 
(00 
crud00 
)00 
{11 
case22 
Crud22 
.22 
Create22  
:22  !
	predicate33 
=33 
	predicate33  )
.33) *
And33* -
(33- .
p33. /
=>330 2
p333 4
.334 5
	CanCreate335 >
)33> ?
;33? @
break44 
;44 
case55 
Crud55 
.55 
Update55  
:55  !
	predicate66 
=66 
	predicate66  )
.66) *
And66* -
(66- .
p66. /
=>660 2
p663 4
.664 5
	CanUpdate665 >
)66> ?
;66? @
break77 
;77 
case88 
Crud88 
.88 
Delete88  
:88  !
	predicate99 
=99 
	predicate99  )
.99) *
And99* -
(99- .
p99. /
=>990 2
p993 4
.994 5
	CanDelete995 >
)99> ?
;99? @
break:: 
;:: 
case;; 
Crud;; 
.;; 
Select;;  
:;;  !
	predicate<< 
=<< 
	predicate<<  )
.<<) *
And<<* -
(<<- .
p<<. /
=><<0 2
p<<3 4
.<<4 5
	CanSelect<<5 >
)<<> ?
;<<? @
break== 
;== 
default>> 
:>> 
throw?? 
new?? '
ArgumentOutOfRangeException?? 9
(??9 :
nameof??: @
(??@ A
crud??A E
)??E F
,??F G
crud??H L
,??L M
null??N R
)??R S
;??S T
}@@ 
}AA 	
}BB 
}CC ˆ
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\UserRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{		 
public

 

class

 
UserRepository

 
:

  !
BaseRepository

" 0
<

0 1
User

1 5
,

5 6
int

7 :
>

: ;
,

; <
IUserRepository

= L
{ 
public 
UserRepository 
( 
	DbContext '
	dbContext( 1
)1 2
:3 4
base5 9
(9 :
	dbContext: C
)C D
{ 	
} 	
public 
async 
Task 
< 
User 
> 
GetByUserNameAsync  2
(2 3
string3 9
userName: B
)B C
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
UserName$ ,
==- /
userName0 8
)8 9
.9 :
FirstOrDefaultAsync: M
(M N
)N O
;O P
} 	
public 
async 
Task 
< 
User 
> 
GetByEmailAsync  /
(/ 0
string0 6
email7 <
)< =
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
Email$ )
==* ,
email- 2
)2 3
.3 4
FirstOrDefaultAsync4 G
(G H
)H I
;I J
} 	
public 
async 
Task 
< 
User 
> )
GetByUserNameAndPasswordAsync  =
(= >
string> D
userNameE M
,M N
stringO U
passwordV ^
)^ _
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
UserName$ ,
==- /
userName0 8
&&9 ;
p< =
.= >
Password> F
==G I
passwordJ R
)R S
.S T
FirstOrDefaultAsyncT g
(g h
)h i
;i j
} 	
public 
async 
Task 
< 
ICustomList %
<% &
User& *
>* +
>+ ,
GetAllAsync- 8
(8 9
)9 :
{   	
return!! 
await!! 
GetAll!! 
(!!  
)!!  !
.!!! "
ToCustomList!!" .
(!!. /
)!!/ 0
;!!0 1
}"" 	
}## 
}$$ ç
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\UserRoleRepository.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Data		4 8
.		8 9
Repositories		9 E
{

 
public 

class 
UserRoleRepository #
:$ %
BaseRepository& 4
<4 5
UserRole5 =
,= >
int? B
>B C
,C D
IUserRoleRepositoryE X
{ 
public 
UserRoleRepository !
(! "
	DbContext" +
	dbContext, 5
)5 6
:7 8
base9 =
(= >
	dbContext> G
)G H
{ 	
} 	
public 
async 
Task 
< 
UserRole "
>" #%
GetByUserIdAndRoleIdAsync$ =
(= >
int> A
userIdB H
,H I
intJ M
roleIdN T
)T U
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
UserId$ *
==+ -
userId. 4
&&5 7
p8 9
.9 :
RoleId: @
==A C
roleIdD J
)J K
.K L
FirstOrDefaultAsyncL _
(_ `
)` a
;a b
} 	
public 
async 
Task 
< 
ICustomList %
<% &
User& *
>* +
>+ ,!
GetUsersByRoleIdAsync- B
(B C
intC F
roleIdG M
)M N
{ 	
return 
await 
GetAll 
(  
p  !
=>" $
p% &
.& '
RoleId' -
==. 0
roleId1 7
)7 8
.8 9
IncludeMultiple9 H
(H I
pI J
=>K M
pN O
.O P
UserP T
)T U
.U V
SelectV \
(\ ]
p] ^
=>_ a
pb c
.c d
Userd h
)h i
. 
ToCustomList 
( 
) 
;  
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Role& *
>* +
>+ ,!
GetRolesByUserIdAsync- B
(B C
intC F
userIdG M
)M N
{ 	
return 
await 
GetAll 
(  
p  !
=>" $
p% &
.& '
UserId' -
==. 0
userId1 7
)7 8
.8 9
IncludeMultiple9 H
(H I
pI J
=>K M
pN O
.O P
RoleP T
)T U
.U V
SelectV \
(\ ]
p] ^
=>_ a
pb c
.c d
Roled h
)h i
. 
ToCustomList 
( 
) 
;  
}   	
}!! 
}"" à
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Repositories\UserUtilRepository.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Repositories9 E
{ 
public 

class 
UserUtilRepository #
:$ %
BaseRepository& 4
<4 5
UserUtil5 =
,= >
int? B
>B C
,C D
IUserUtilRepositoryE X
{		 
public

 
UserUtilRepository

 !
(

! "
	DbContext

" +
	dbContext

, 5
)

5 6
:

7 8
base

9 =
(

= >
	dbContext

> G
)

G H
{ 	
} 	
public 
async 
Task 
< 
UserUtil "
>" #
GetByUserIdAsync$ 4
(4 5
int5 8
userId9 ?
)? @
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
UserId$ *
==+ -
userId. 4
)4 5
.5 6
FirstOrDefaultAsync6 I
(I J
)J K
;K L
} 	
} 
} Ô
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Seeding\ISeedAuthorizationData.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
.8 9
Seeding9 @
{ 
public 

	interface "
ISeedAuthorizationData +
{ 
IList		 
<		 
ClientApplication		 
>		  
ClientApplications		! 3
{		4 5
get		6 9
;		9 :
set		; >
;		> ?
}		@ A
IList

 
<

 
Role

 
>

 
Roles

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
IList 
< 
User 
> 
Users 
{ 
get 
;  
set! $
;$ %
}& '
IList 
< 
UserRole 
> 
	UserRoles !
{" #
get$ '
;' (
set) ,
;, -
}. /
IList 
< 
RoleEntityClaim 
> 
RoleEntityClaims /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
void 
SeedUserData 
( 
ModelBuilder &
modelBuilder' 3
)3 4
;4 5
void %
SeedClientApplicationData &
(& '
ModelBuilder' 3
modelBuilder4 @
)@ A
;A B
void 
SeedRoleData 
( 
ModelBuilder &
modelBuilder' 3
)3 4
;4 5
void 
SeedUserRoleData 
( 
ModelBuilder *
modelBuilder+ 7
)7 8
;8 9
void 
SeedRoleEntityData 
(  
ModelBuilder  ,
modelBuilder- 9
)9 :
;: ;
void 
SeedAll 
( 
ModelBuilder !
modelBuilder" .
). /
;/ 0
} 
} ”L
C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\Seeding\SeedAuthorizationData.cs
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
% &
Authorization

& 3
.

3 4
Data

4 8
.

8 9
Seeding

9 @
{ 
public 

class !
SeedAuthorizationData &
:' ("
ISeedAuthorizationData) ?
{ 
private 
static 
int #
ClientApplicationUtilId 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
private 
static 
int 

UserUtilId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public !
SeedAuthorizationData $
($ %
)% &
{ 	
ClientApplications 
=  
new! $
List% )
<) *
ClientApplication* ;
>; <
(< =
)= >
;> ?
RoleEntityClaims 
= 
new "
List# '
<' (
RoleEntityClaim( 7
>7 8
(8 9
)9 :
;: ;
Roles 
= 
new 
List 
< 
Role !
>! "
(" #
)# $
;$ %
Users 
= 
new 
List 
< 
User !
>! "
(" #
)# $
;$ %#
ClientApplicationUtilId #
=$ %
$num& '
;' (

UserUtilId 
= 
$num 
; 
} 	
public 
IList 
< 
ClientApplication &
>& '
ClientApplications( :
{; <
get= @
;@ A
setB E
;E F
}G H
public 
IList 
< 
Role 
> 
Roles  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
IList 
< 
User 
> 
Users  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
IList 
< 
UserRole 
> 
	UserRoles (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
IList 
< 
RoleEntityClaim $
>$ %
RoleEntityClaims& 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public!! 
void!! 
SeedUserData!!  
(!!  !
ModelBuilder!!! -
modelBuilder!!. :
)!!: ;
{"" 	
foreach## 
(## 
var## 
user## 
in##  
Users##! &
)##& '
{$$ 
var%% 
salt%% 
=%% 

HashString%% %
.%%% &
GetSalt%%& -
(%%- .
)%%. /
;%%/ 0
var&& 
hashPassword&&  
=&&! "

HashString&&# -
.&&- .
Hash&&. 2
(&&2 3
user&&3 7
.&&7 8
Password&&8 @
,&&@ A
salt&&B F
,'' &
AuthorizationUtilConstants'' 0
.''0 1$
IterationCountForHashing''1 I
)''I J
;''J K
var)) 
userUtil)) 
=)) 
new)) "
UserUtil))# +
{** 
Id++ 
=++ 

UserUtilId++ #
,++# $
UserId,, 
=,, 
user,, !
.,,! "
Id,," $
,,,$ %
SpecialValue--  
=--! "
salt--# '
,--' (
}.. 
;.. 
user00 
.00 
Password00 
=00 
hashPassword00  ,
;00, -
SeedDataUtil22 
.22 
SetCommonFields22 ,
<22, -
User22- 1
,221 2
int223 6
>226 7
(227 8
user228 <
)22< =
;22= >
SeedDataUtil33 
.33 
SetCommonFields33 ,
<33, -
UserUtil33- 5
,335 6
int337 :
>33: ;
(33; <
userUtil33< D
)33D E
;33E F
modelBuilder55 
.55 
Entity55 #
<55# $
User55$ (
>55( )
(55) *
)55* +
.66 
HasData66 
(66 
user66 !
)66! "
;66" #
modelBuilder88 
.88 
Entity88 #
<88# $
UserUtil88$ ,
>88, -
(88- .
)88. /
.99 
HasData99 
(99 
userUtil99 %
)99% &
;99& '

UserUtilId;; 
++;; 
;;; 
}<< 
}== 	
public?? 
void?? %
SeedClientApplicationData?? -
(??- .
ModelBuilder??. :
modelBuilder??; G
)??G H
{@@ 	
foreachAA 
(AA 
varAA 
clientApplicationAA *
inAA+ -
ClientApplicationsAA. @
)AA@ A
{BB 
varCC 
saltCC 
=CC 

HashStringCC %
.CC% &
GetSaltCC& -
(CC- .
)CC. /
;CC/ 0
varDD 
hashPasswordDD  
=DD! "

HashStringDD# -
.DD- .
HashDD. 2
(DD2 3
clientApplicationDD3 D
.DDD E%
ClientApplicationPasswordDDE ^
,DD^ _
saltDD` d
,EE &
AuthorizationUtilConstantsEE 0
.EE0 1$
IterationCountForHashingEE1 I
)EEI J
;EEJ K
varFF !
clientApplicationUtilFF )
=FF* +
newFF, /!
ClientApplicationUtilFF0 E
(FFE F
)FFF G
{GG 
IdHH 
=HH #
ClientApplicationUtilIdHH 0
,HH0 1
ClientApplicationIdII '
=II( )
clientApplicationII* ;
.II; <
IdII< >
,II> ?
SpecialValueJJ  
=JJ! "
saltJJ# '
,JJ' (
}KK 
;KK 
clientApplicationMM !
.MM! "%
ClientApplicationPasswordMM" ;
=MM< =
hashPasswordMM> J
;MMJ K
SeedDataUtilOO 
.OO 
SetCommonFieldsOO ,
<OO, -
ClientApplicationOO- >
,OO> ?
intOO@ C
>OOC D
(OOD E
clientApplicationOOE V
)OOV W
;OOW X
SeedDataUtilPP 
.PP 
SetCommonFieldsPP ,
<PP, -!
ClientApplicationUtilPP- B
,PPB C
intPPD G
>PPG H
(PPH I!
clientApplicationUtilPPI ^
)PP^ _
;PP_ `
modelBuilderRR 
.RR 
EntityRR #
<RR# $
ClientApplicationRR$ 5
>RR5 6
(RR6 7
)RR7 8
.SS 
HasDataSS 
(SS 
clientApplicationSS .
)SS. /
;SS/ 0
modelBuilderUU 
.UU 
EntityUU #
<UU# $!
ClientApplicationUtilUU$ 9
>UU9 :
(UU: ;
)UU; <
.VV 
HasDataVV 
(VV !
clientApplicationUtilVV 2
)VV2 3
;VV3 4#
ClientApplicationUtilIdXX '
++XX' )
;XX) *
}YY 
}ZZ 	
public\\ 
void\\ 
SeedRoleData\\  
(\\  !
ModelBuilder\\! -
modelBuilder\\. :
)\\: ;
{]] 	
SeedDataUtil^^ 
.^^ 
	SeedTData^^ "
<^^" #
Role^^# '
,^^' (
int^^) ,
>^^, -
(^^- .
modelBuilder^^. :
,^^: ;
Roles^^< A
)^^A B
;^^B C
}__ 	
publicaa 
voidaa 
SeedUserRoleDataaa $
(aa$ %
ModelBuilderaa% 1
modelBuilderaa2 >
)aa> ?
{bb 	
SeedDataUtilcc 
.cc 
	SeedTDatacc "
<cc" #
UserRolecc# +
,cc+ ,
intcc- 0
>cc0 1
(cc1 2
modelBuildercc2 >
,cc> ?
	UserRolescc@ I
)ccI J
;ccJ K
}dd 	
publicff 
voidff 
SeedRoleEntityDataff &
(ff& '
ModelBuilderff' 3
modelBuilderff4 @
)ff@ A
{gg 	
SeedDataUtilhh 
.hh 
	SeedTDatahh "
<hh" #
RoleEntityClaimhh# 2
,hh2 3
inthh4 7
>hh7 8
(hh8 9
modelBuilderhh9 E
,hhE F
RoleEntityClaimshhG W
)hhW X
;hhX Y
}ii 	
publickk 
voidkk 
SeedAllkk 
(kk 
ModelBuilderkk (
modelBuilderkk) 5
)kk5 6
{ll 	
SeedUserDatamm 
(mm 
modelBuildermm %
)mm% &
;mm& '%
SeedClientApplicationDatann %
(nn% &
modelBuildernn& 2
)nn2 3
;nn3 4
SeedRoleDataoo 
(oo 
modelBuilderoo %
)oo% &
;oo& '
SeedUserRoleDatapp 
(pp 
modelBuilderpp )
)pp) *
;pp* +
SeedRoleEntityDataqq 
(qq 
modelBuilderqq +
)qq+ ,
;qq, -
}rr 	
}ss 
}tt ≠ 
yC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Data\UnitOfWorkAuthorization.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Data4 8
{ 
public 

class #
UnitOfWorkAuthorization (
:) *

UnitOfWork+ 5
<5 6 
AuthorizationContext6 J
>J K
,K L$
IUnitOfWorkAuthorizationM e
{ 
public		 #
UnitOfWorkAuthorization		 &
(		& ' 
AuthorizationContext		' ;
context		< C
)		C D
:		E F
base		G K
(		K L
context		L S
)		S T
{

 	
Claims 
= 
new 
ClaimRepository (
(( )
context) 0
)0 1
;1 2
ClientApplications 
=  
new! $'
ClientApplicationRepository% @
(@ A
contextA H
)H I
;I J"
ClientApplicationUtils "
=# $
new% (+
ClientApplicationUtilRepository) H
(H I
contextI P
)P Q
;Q R

RoleClaims 
= 
new 
RoleClaimRepository 0
(0 1
context1 8
)8 9
;9 :
RoleEntityClaims 
= 
new "%
RoleEntityClaimRepository# <
(< =
context= D
)D E
;E F
Roles 
= 
new 
RoleRepository &
(& '
context' .
). /
;/ 0

UserClaims 
= 
new 
UserClaimRepository 0
(0 1
context1 8
)8 9
;9 :
UserEntityClaims 
= 
new "%
UserEntityClaimRepository# <
(< =
context= D
)D E
;E F
Users 
= 
new 
UserRepository &
(& '
context' .
). /
;/ 0
	UserRoles 
= 
new 
UserRoleRepository .
(. /
context/ 6
)6 7
;7 8
	UserUtils 
= 
new 
UserUtilRepository .
(. /
context/ 6
)6 7
;7 8
} 	
public 
IClaimRepository 
Claims  &
{' (
get) ,
;, -
}. /
public (
IClientApplicationRepository +
ClientApplications, >
{? @
getA D
;D E
}F G
public ,
 IClientApplicationUtilRepository /"
ClientApplicationUtils0 F
{G H
getI L
;L M
}N O
public  
IRoleClaimRepository #

RoleClaims$ .
{/ 0
get1 4
;4 5
}6 7
public &
IRoleEntityClaimRepository )
RoleEntityClaims* :
{; <
get= @
;@ A
}B C
public 
IRoleRepository 
Roles $
{% &
get' *
;* +
}, -
public  
IUserClaimRepository #

UserClaims$ .
{/ 0
get1 4
;4 5
}6 7
public &
IUserEntityClaimRepository )
UserEntityClaims* :
{; <
get= @
;@ A
}B C
public   
IUserRepository   
Users   $
{  % &
get  ' *
;  * +
}  , -
public!! 
IUserRoleRepository!! "
	UserRoles!!# ,
{!!- .
get!!/ 2
;!!2 3
}!!4 5
public"" 
IUserUtilRepository"" "
	UserUtils""# ,
{""- .
get""/ 2
;""2 3
}""4 5
}## 
}$$ ›O
ãC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Extensions\AuthorizationModelsServiceExtension.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Extensions4 >
{ 
public 

static 
class /
#AuthorizationModelsServiceExtension ;
{ 
public 
static 
IServiceCollection ("
AddAuthorizationModels) ?
(? @
this@ D
IServiceCollectionE W
servicesX `
)` a
{ 	
services 
. 
AddTransient !
<! "$
IUnitOfWorkAuthorization" :
,: ;#
UnitOfWorkAuthorization< S
>S T
(T U
)U V
;V W
services 
. 
	AddScoped 
< 
	DbContext (
,( ) 
AuthorizationContext* >
>> ?
(? @
)@ A
;A B
services 
. 
AddTransient !
<! "!
IAuthorizationHandler" 7
,7 8*
PermissionAuthorizationHandler9 W
>W X
(X Y
)Y Z
;Z [
services 
. 
AddTransient !
<! "
IApiRequestAccessor" 5
,5 6
ApiRequestAccessor7 I
>I J
(J K
)K L
;L M
services 
. 
AddTransient !
<! "
IApiRequest" -
,- .

ApiRequest/ 9
>9 :
(: ;
); <
;< =
services 
. 
AddSingleton !
<! "
IToken" (
,( )
Token* /
>/ 0
(0 1
)1 2
;2 3
services 
. 
AddTransient !
<! "
IClaimRepository" 2
,2 3
ClaimRepository4 C
>C D
(D E
)E F
;F G
services   
.   
AddTransient   !
<  ! "(
IClientApplicationRepository  " >
,  > ?'
ClientApplicationRepository  @ [
>  [ \
(  \ ]
)  ] ^
;  ^ _
services!! 
.!! 
AddTransient!! !
<!!! ",
 IClientApplicationUtilRepository!!" B
,!!B C+
ClientApplicationUtilRepository!!D c
>!!c d
(!!d e
)!!e f
;!!f g
services"" 
."" 
AddTransient"" !
<""! " 
IRoleClaimRepository""" 6
,""6 7
RoleClaimRepository""8 K
>""K L
(""L M
)""M N
;""N O
services## 
.## 
AddTransient## !
<##! "&
IRoleEntityClaimRepository##" <
,##< =%
RoleEntityClaimRepository##> W
>##W X
(##X Y
)##Y Z
;##Z [
services$$ 
.$$ 
AddTransient$$ !
<$$! "
IRoleRepository$$" 1
,$$1 2
RoleRepository$$3 A
>$$A B
($$B C
)$$C D
;$$D E
services%% 
.%% 
AddTransient%% !
<%%! " 
IUserClaimRepository%%" 6
,%%6 7
UserClaimRepository%%8 K
>%%K L
(%%L M
)%%M N
;%%N O
services&& 
.&& 
AddTransient&& !
<&&! "&
IUserEntityClaimRepository&&" <
,&&< =%
UserEntityClaimRepository&&> W
>&&W X
(&&X Y
)&&Y Z
;&&Z [
services'' 
.'' 
AddTransient'' !
<''! "
IUserRepository''" 1
,''1 2
UserRepository''3 A
>''A B
(''B C
)''C D
;''D E
services(( 
.(( 
AddTransient(( !
<((! "
IUserRoleRepository((" 5
,((5 6
UserRoleRepository((7 I
>((I J
(((J K
)((K L
;((L M
services)) 
.)) 
AddTransient)) !
<))! "
IUserUtilRepository))" 5
,))5 6
UserUtilRepository))7 I
>))I J
())J K
)))K L
;))L M
services-- 
.-- 
AddTransient-- !
<--! "
IClaimManager--" /
,--/ 0
ClaimManager--1 =
>--= >
(--> ?
)--? @
;--@ A
services.. 
... 
AddTransient.. !
<..! "%
IClientApplicationManager.." ;
,..; <$
ClientApplicationManager..= U
>..U V
(..V W
)..W X
;..X Y
services// 
.// 
AddTransient// !
<//! ")
IClientApplicationUtilManager//" ?
,//? @(
ClientApplicationUtilManager//A ]
>//] ^
(//^ _
)//_ `
;//` a
services00 
.00 
AddTransient00 !
<00! "
IRoleClaimManager00" 3
,003 4
RoleClaimManager005 E
>00E F
(00F G
)00G H
;00H I
services11 
.11 
AddTransient11 !
<11! "
IRoleManager11" .
,11. /
RoleManager110 ;
>11; <
(11< =
)11= >
;11> ?
services22 
.22 
AddTransient22 !
<22! "#
IRoleEntityClaimManager22" 9
,229 :"
RoleEntityClaimManager22; Q
>22Q R
(22R S
)22S T
;22T U
services33 
.33 
AddTransient33 !
<33! "
IUserClaimManager33" 3
,333 4
UserClaimManager335 E
>33E F
(33F G
)33G H
;33H I
services44 
.44 
AddTransient44 !
<44! "
IUserManager44" .
,44. /
UserManager440 ;
>44; <
(44< =
)44= >
;44> ?
services55 
.55 
AddTransient55 !
<55! "#
IUserEntityClaimManager55" 9
,559 :"
UserEntityClaimManager55; Q
>55Q R
(55R S
)55S T
;55T U
services66 
.66 
AddTransient66 !
<66! "
IUserRoleManager66" 2
,662 3
UserRoleManager664 C
>66C D
(66D E
)66E F
;66F G
services77 
.77 
AddTransient77 !
<77! "
IUserUtilManager77" 2
,772 3
UserUtilManager774 C
>77C D
(77D E
)77E F
;77F G
services;; 
.;; 
AddTransient;; !
<;;! ",
 ClientApplicationDataInitializer;;" B
>;;B C
(;;C D
);;D E
;;;E F
services<< 
.<< 
AddTransient<< !
<<<! "*
RoleEntityClaimDataInitializer<<" @
><<@ A
(<<A B
)<<B C
;<<C D
services== 
.== 
AddTransient== !
<==! "
RoleDataInitializer==" 5
>==5 6
(==6 7
)==7 8
;==8 9
services>> 
.>> 
AddTransient>> !
<>>! "
UserDataInitializer>>" 5
>>>5 6
(>>6 7
)>>7 8
;>>8 9
services?? 
.?? 
AddTransient?? !
<??! "#
UserRoleDataInitializer??" 9
>??9 :
(??: ;
)??; <
;??< =
servicesCC 
.CC 
AddTransientCC !
<CC! "

IValidatorCC" ,
<CC, -
ClaimRequestCC- 9
>CC9 :
,CC: ;
ClaimValidatorCC< J
>CCJ K
(CCK L
)CCL M
;CCM N
servicesDD 
.DD 
AddTransientDD !
<DD! "

IValidatorDD" ,
<DD, -$
ClientApplicationRequestDD- E
>DDE F
,DDF G&
ClientApplicationValidatorDDH b
>DDb c
(DDc d
)DDd e
;DDe f
servicesEE 
.EE 
AddTransientEE !
<EE! "

IValidatorEE" ,
<EE, -
RoleRequestEE- 8
>EE8 9
,EE9 :
RoleValidatorEE; H
>EEH I
(EEI J
)EEJ K
;EEK L
servicesFF 
.FF 
AddTransientFF !
<FF! "

IValidatorFF" ,
<FF, -
RoleClaimRequestFF- =
>FF= >
,FF> ?
RoleClaimValidatorFF@ R
>FFR S
(FFS T
)FFT U
;FFU V
servicesGG 
.GG 
AddTransientGG !
<GG! "

IValidatorGG" ,
<GG, -"
RoleEntityClaimRequestGG- C
>GGC D
,GGD E$
RoleEntityClaimValidatorGGF ^
>GG^ _
(GG_ `
)GG` a
;GGa b
servicesHH 
.HH 
AddTransientHH !
<HH! "

IValidatorHH" ,
<HH, -
UserRequestHH- 8
>HH8 9
,HH9 :
UserValidatorHH; H
>HHH I
(HHI J
)HHJ K
;HHK L
servicesII 
.II 
AddTransientII !
<II! "

IValidatorII" ,
<II, -
UserClaimRequestII- =
>II= >
,II> ?
UserClaimValidatorII@ R
>IIR S
(IIS T
)IIT U
;IIU V
servicesJJ 
.JJ 
AddTransientJJ !
<JJ! "

IValidatorJJ" ,
<JJ, -"
UserEntityClaimRequestJJ- C
>JJC D
,JJD E$
UserEntityClaimValidatorJJF ^
>JJ^ _
(JJ_ `
)JJ` a
;JJa b
servicesKK 
.KK 
AddTransientKK !
<KK! "

IValidatorKK" ,
<KK, -
UserRoleRequestKK- <
>KK< =
,KK= >
UserRoleValidatorKK? P
>KKP Q
(KKQ R
)KKR S
;KKS T
returnNN 
servicesNN 
;NN 
}OO 	
}PP 
}QQ Ä
{C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Filters\ValidateModelAttribute.cs
	namespace		 	
CustomFramework		
 
.		 
WebApiUtils		 %
.		% &
Authorization		& 3
.		3 4
Filters		4 ;
{

 
public 

class "
ValidateModelAttribute '
:( )!
ActionFilterAttribute* ?
{ 
private 
readonly  
ILocalizationService - 
_localizationService. B
;B C
private 
readonly 
ILogger  
<  !"
ValidateModelAttribute! 7
>7 8
_logger9 @
;@ A
public "
ValidateModelAttribute %
(% & 
ILocalizationService& :
localizationService; N
,N O
ILoggerP W
<W X"
ValidateModelAttributeX n
>n o
loggerp v
)v w
{ 	 
_localizationService  
=! "
localizationService# 6
;6 7
_logger 
= 
logger 
; 
} 	
public 
override 
void 
OnActionExecuting .
(. /"
ActionExecutingContext/ E
contextF M
)M N
{ 	
if 
( 
! 
context 
. 

ModelState #
.# $
IsValid$ +
)+ ,
{ 
var 
apiResponse 
=  !
new" %
ApiResponse& 1
(1 2 
_localizationService2 F
,F G
_loggerH O
)O P
. 
ModelStateError $
($ %
context% ,
., -

ModelState- 7
)7 8
;8 9
context 
. 
Result 
=  
new! $"
BadRequestObjectResult% ;
(; <
apiResponse< G
)G H
;H I
} 
} 	
}   
}!! çX
ÑC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Handlers\PermissionAuthorizationHandler.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Handlers4 <
{ 
public 

class *
PermissionAuthorizationHandler /
:0 1)
AttributeAuthorizationHandler2 O
<O P.
"PermissionAuthorizationRequirementP r
,r s 
PermissionAttribute	t á
>
á à
{ 
private 
readonly 
ILogger  
_logger! (
;( )
private 
readonly 
IApiRequest $
_apiRequest% 0
;0 1
private 
readonly 
IUserRoleManager )
_userRoleManager* :
;: ;
private 
readonly 
IClaimManager &
_claimManager' 4
;4 5
private 
readonly 
IRoleClaimManager *
_roleClaimManager+ <
;< =
private 
readonly 
IUserClaimManager *
_userClaimManager+ <
;< =
private 
readonly #
IRoleEntityClaimManager 0#
_roleEntityClaimManager1 H
;H I
private 
readonly #
IUserEntityClaimManager 0#
_userEntityClaimManager1 H
;H I
public   *
PermissionAuthorizationHandler   -
(  - .
ILogger  . 5
logger  6 <
,  < =
IApiRequestAccessor  > Q
apiRequestAccessor  R d
,  d e
IUserRoleManager  f v
userRoleManager	  w Ü
,
  Ü á
IClaimManager
  à ï
claimManager
  ñ ¢
,
  ¢ £
IRoleClaimManager
  § µ
roleClaimManager
  ∂ ∆
,
  ∆ «
IUserClaimManager
  » Ÿ
userClaimManager
  ⁄ Í
,
  Í Î%
IRoleEntityClaimManager
  Ï É$
roleEntityClaimManager
  Ñ ö
,
  ö õ%
IUserEntityClaimManager
  ú ≥$
userEntityClaimManager
  ¥  
)
    À
{!! 	
_logger"" 
="" 
logger"" 
;"" 
_apiRequest## 
=## 
apiRequestAccessor## ,
.##, -
GetApiRequest##- :
<##: ;

ApiRequest##; E
>##E F
(##F G
)##G H
;##H I
_userRoleManager$$ 
=$$ 
userRoleManager$$ .
;$$. /
_claimManager%% 
=%% 
claimManager%% (
;%%( )
_roleClaimManager&& 
=&& 
roleClaimManager&&  0
;&&0 1
_userClaimManager'' 
='' 
userClaimManager''  0
;''0 1#
_roleEntityClaimManager(( #
=(($ %"
roleEntityClaimManager((& <
;((< =#
_userEntityClaimManager)) #
=))$ %"
userEntityClaimManager))& <
;))< =
}** 	
	protected-- 
override-- 
async--  
Task--! %"
HandleRequirementAsync--& <
(--< ='
AuthorizationHandlerContext--= X
context--Y `
,..< =.
"PermissionAuthorizationRequirement..> `
requirement..a l
,//< =
IEnumerable//> I
<//I J
PermissionAttribute//J ]
>//] ^

attributes//_ i
)//i j
{00 	
var11 
claimsPrincipal11 
=11  !
context11" )
.11) *
User11* .
;11. /
UserIsAuthenticated33 
(33  
claimsPrincipal33  /
)33/ 0
;330 1
try55 
{66 
var77 
userId77 
=77 
_apiRequest77 (
.77( )
User77) -
.77- .
Id77. 0
;770 1
var88 
roles88 
=88 
(88 
await88 "
_userRoleManager88# 3
.883 4!
GetRolesByUserIdAsync884 I
(88I J
userId88J P
)88P Q
)88Q R
.88R S

ResultList88S ]
;88] ^
foreach:: 
(:: 
var:: 
permissionAttribute:: 0
in::1 3

attributes::4 >
)::> ?
{;; 
if<< 
(<< 
permissionAttribute<< +
.<<+ ,
CustomClaim<<, 7
!=<<8 :
null<<; ?
)<<? @
{== 
await>> !
CheckCustomClaimAsync>> 3
(>>3 4
userId>>4 :
,>>: ;
roles>>< A
,>>A B
permissionAttribute>>C V
.>>V W
CustomClaim>>W b
)>>b c
;>>c d
}?? 
else@@ 
if@@ 
(@@ 
permissionAttribute@@ 0
.@@0 1
Entity@@1 7
!=@@8 :
null@@; ?
&&@@@ B
permissionAttribute@@C V
.@@V W
Crud@@W [
!=@@\ ^
null@@_ c
)@@c d
{AA 
awaitBB !
CheckEntityClaimAsyncBB 3
(BB3 4
userIdBB4 :
,BB: ;
rolesBB< A
,BBA B
permissionAttributeBBC V
.BBV W
EntityBBW ]
,BB] ^
(BB_ `
CrudBB` d
)BBd e
permissionAttributeBBe x
.BBx y
CrudBBy }
)BB} ~
;BB~ 
}CC 
elseDD 
{EE 
throwFF 
newFF ! 
KeyNotFoundExceptionFF" 6
(FF6 7
)FF7 8
;FF8 9
}GG 
}HH 
}II 
catchJJ 
(JJ  
KeyNotFoundExceptionJJ '
)JJ' (
{KK 
throwLL 
newLL '
UnauthorizedAccessExceptionLL 5
(LL5 6
)LL6 7
;LL7 8
}MM 
catchNN 
(NN 
	ExceptionNN 
exNN 
)NN  
{OO 
_loggerPP 
.PP 
LogCriticalPP #
(PP# $
exPP$ &
.PP& '
MessagePP' .
)PP. /
;PP/ 0
throwQQ 
newQQ 
	ExceptionQQ #
(QQ# $#
DefaultResponseMessagesQQ$ ;
.QQ; <
AnErrorHasOccuredQQ< M
)QQM N
;QQN O
}RR 
contextTT 
.TT 
SucceedTT 
(TT 
requirementTT '
)TT' (
;TT( )
}UU 	
privateWW 
staticWW 
voidWW 
UserIsAuthenticatedWW /
(WW/ 0
ClaimsPrincipalWW0 ?
claimsPrincipalWW@ O
)WWO P
{XX 	
ifYY 
(YY 
claimsPrincipalYY 
==YY  "
nullYY# '
||YY( *
!YY+ ,
claimsPrincipalYY, ;
.YY; <
IdentityYY< D
.YYD E
IsAuthenticatedYYE T
)YYT U
{ZZ 
throw[[ 
new[[ '
UnauthorizedAccessException[[ 5
([[5 6#
DefaultResponseMessages[[6 M
.[[M N#
UnauthorizedAccessError[[N e
)[[e f
;[[f g
}\\ 
}]] 	
private__ 
async__ 
Task__ !
CheckCustomClaimAsync__ 0
(__0 1
int__1 4
userId__5 ;
,__; <
IList__= B
<__B C
Role__C G
>__G H
roles__I N
,__N O
string__P V
customClaim__W b
)__b c
{`` 	
varaa 
claimaa 
=aa 
awaitaa 
_claimManageraa +
.aa+ ,!
GetByCustomClaimAsyncaa, A
(aaA B
customClaimaaB M
)aaM N
;aaN O
awaitbb )
AuthorizeWithCustomClaimAsyncbb /
(bb/ 0
userIdbb0 6
,bb6 7
rolesbb8 =
,bb= >
claimbb? D
.bbD E
IdbbE G
)bbG H
;bbH I
}cc 	
privateee 
asyncee 
Taskee !
CheckEntityClaimAsyncee 0
(ee0 1
intee1 4
userIdee5 ;
,ee; <
IListee= B
<eeB C
RoleeeC G
>eeG H
roleseeI N
,eeN O
stringeeP V
entityeeW ]
,ee] ^
Crudee_ c
crudeed h
)eeh i
{ff 	
awaitgg )
AuthorizeWithEntityClaimAsyncgg /
(gg/ 0
userIdgg0 6
,gg6 7
rolesgg8 =
,gg= >
entitygg? E
,ggE F
crudggG K
)ggK L
;ggL M
}hh 	
privatejj 
asyncjj 
Taskjj )
AuthorizeWithCustomClaimAsyncjj 8
(jj8 9
intjj9 <
userIdjj= C
,jjC D
IListjjE J
<jjJ K
RolejjK O
>jjO P
rolesjjQ V
,jjV W
intjjX [
claimIdjj\ c
)jjc d
{kk 	
varll 
userIsAuthorizedll  
=ll! "
awaitll# (
_userClaimManagerll) :
.ll: ;)
UserIsAuthorizedForClaimAsyncll; X
(llX Y
userIdllY _
,ll_ `
claimIdlla h
)llh i
;lli j
varmm 
roleIsAuthorizedmm  
=mm! "
awaitmm# (
_roleClaimManagermm) :
.mm: ;+
RolesAreAuthorizedForClaimAsyncmm; Z
(mmZ [
rolesmm[ `
,mm` a
claimIdmmb i
)mmi j
;mmj k
ifnn 
(nn 
userIsAuthorizednn  
||nn! #
roleIsAuthorizednn$ 4
)nn4 5
{oo 
returnpp 
;pp 
}qq 
throwss 
newss  
KeyNotFoundExceptionss *
(ss* +
)ss+ ,
;ss, -
}tt 	
privatevv 
asyncvv 
Taskvv )
AuthorizeWithEntityClaimAsyncvv 8
(vv8 9
intvv9 <
userIdvv= C
,vvC D
IListvvE J
<vvJ K
RolevvK O
>vvO P
rolesvvQ V
,vvV W
stringvvX ^
entityvv_ e
,vve f
Crudvvg k
crudvvl p
)vvp q
{ww 	
varxx 
userIsAuthorizedxx  
=xx! "
awaitxx# (#
_userEntityClaimManagerxx) @
.xx@ A/
#UserIsAuthorizedForEntityClaimAsyncxxA d
(xxd e
userIdxxe k
,xxk l
entityxxm s
,xxs t
crudxxu y
)xxy z
;xxz {
varyy 
roleIsAuthorizedyy  
=yy! "
awaityy# (#
_roleEntityClaimManageryy) @
.yy@ A1
%RolesAreAuthorizedForEntityClaimAsyncyyA f
(yyf g
rolesyyg l
,yyl m
entityyyn t
,yyt u
crudyyv z
)yyz {
;yy{ |
if{{ 
({{ 
userIsAuthorized{{  
||{{! #
roleIsAuthorized{{$ 4
){{4 5
{|| 
return}} 
;}} 
}~~ 
throw
ÄÄ 
new
ÄÄ "
KeyNotFoundException
ÄÄ *
(
ÄÄ* +
)
ÄÄ+ ,
;
ÄÄ, -
}
ÅÅ 	
}
ÉÉ 
}ÑÑ à	
iC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\Claim.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
Claim 
: 
	BaseModel "
<" #
int# &
>& '
{		 
public

 
string

 
CustomClaim

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
[ 	

JsonIgnore	 
] 
public 
IList 
< 
	RoleClaim 
> 

RoleClaims  *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	

JsonIgnore	 
] 
public 
IList 
< 
	UserClaim 
> 

UserClaims  *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} ﬁ	
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\ClientApplication.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
ClientApplication "
:# $
	BaseModel% .
<. /
int/ 2
>2 3
{ 
public 
string !
ClientApplicationName +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public		 
string		 !
ClientApplicationCode		 +
{		, -
get		. 1
;		1 2
set		3 6
;		6 7
}		8 9
public

 
string

 %
ClientApplicationPassword

 /
{

0 1
get

2 5
;

5 6
set

7 :
;

: ;
}

< =
[ 	

JsonIgnore	 
] 
public !
ClientApplicationUtil $!
ClientApplicationUtil% :
{; <
get= @
;@ A
setB E
;E F
}G H
} 
} £
yC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\ClientApplicationUtil.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class !
ClientApplicationUtil &
:' (
	BaseModel) 2
<2 3
int3 6
>6 7
{ 
public 
string 
SpecialValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
int		 
ClientApplicationId		 &
{		' (
get		) ,
;		, -
set		. 1
;		1 2
}		3 4
[ 	

JsonIgnore	 
] 
public 
ClientApplication  
ClientApplication! 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} ¥
hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\Role.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
Role 
: 
	BaseModel !
<! "
int" %
>% &
{ 
public		 
string		 
RoleName		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
string

 
Description

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
[ 	

JsonIgnore	 
] 
public 
IList 
< 
	RoleClaim 
> 

RoleClaims  *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	

JsonIgnore	 
] 
public 
IList 
< 
RoleEntityClaim $
>$ %
RoleEntityClaims& 6
{7 8
get9 <
;< =
set> A
;A B
}C D
[ 	

JsonIgnore	 
] 
public 
IList 
< 
UserRole 
> 
	UserRoles (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ™	
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\RoleClaim.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
	RoleClaim 
: 
	BaseModel &
<& '
int' *
>* +
{ 
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
int		 
ClaimId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
[ 	

JsonIgnore	 
] 
public 
Role 
Role 
{ 
get 
; 
set  #
;# $
}% &
[ 	

JsonIgnore	 
] 
public 
Claim 
Claim 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ÷
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\RoleEntityClaim.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
RoleEntityClaim  
:! "
	BaseModel# ,
<, -
int- 0
>0 1
{ 
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
string		 
Entity		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
bool

 
	CanSelect

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	

JsonIgnore	 
] 
public 
Role 
Role 
{ 
get 
; 
set  #
;# $
}% &
} 
} •
hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\User.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
User 
: 
	BaseModel !
<! "
int" %
>% &
{		 
public

 
string

 
UserName

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
bool 
EmailConfirmed "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
EmailConfirmCode &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
int 
AccessFailedCount $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
bool 
Lockout 
{ 
get !
;! "
set# &
;& '
}( )
public 
DateTime 
? 
LockoutEndDateTime +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
[ 	

JsonIgnore	 
] 
public 
UserUtil 
UserUtil  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	

JsonIgnore	 
] 
public 
virtual 
ICollection "
<" #
	UserClaim# ,
>, -

UserClaims. 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
[ 	

JsonIgnore	 
] 
public 
virtual 
ICollection "
<" #
UserEntityClaim# 2
>2 3
UserEntityClaims4 D
{E F
getG J
;J K
setL O
;O P
}Q R
[ 	

JsonIgnore	 
] 
public 
virtual 
ICollection "
<" #
UserRole# +
>+ ,
	UserRoles- 6
{7 8
get9 <
;< =
set> A
;A B
}C D
} 
}   ™	
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\UserClaim.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
	UserClaim 
: 
	BaseModel &
<& '
int' *
>* +
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
int		 
ClaimId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
[ 	

JsonIgnore	 
] 
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
[ 	

JsonIgnore	 
] 
public 
Claim 
Claim 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ÷
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\UserEntityClaim.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
UserEntityClaim  
:! "
	BaseModel# ,
<, -
int- 0
>0 1
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
string		 
Entity		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
bool

 
	CanSelect

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	

JsonIgnore	 
] 
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
} 
} œ	
lC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\UserRole.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
UserRole 
: 
	BaseModel %
<% &
int& )
>) *
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
int		 
RoleId		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
[ 	

JsonIgnore	 
] 
public 
virtual 
User 
User  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	

JsonIgnore	 
] 
public 
virtual 
Role 
Role  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} ‚
lC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Models\UserUtil.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Models4 :
{ 
public 

class 
UserUtil 
: 
	BaseModel %
<% &
int& )
>) *
{ 
public 
string 
SpecialValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
int		 
UserId		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
[ 	

JsonIgnore	 
] 
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
} 
} ≥
qC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\ClaimRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
ClaimRequest 
{ 
public 
string 
CustomClaim !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
}		 ´
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\ClientApplicationRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class $
ClientApplicationRequest )
{ 
public 
string !
ClientApplicationName +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string !
ClientApplicationCode +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string %
ClientApplicationPassword /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
} 
}		 ã
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\ClientApplicationUpdateRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class *
ClientApplicationUpdateRequest /
{ 
public 
string !
ClientApplicationName +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string !
ClientApplicationCode +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} ˘
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\ClientApplicationUtilRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class (
ClientApplicationUtilRequest -
{ 
public 
string 
SpecialValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 
ClientApplicationId &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} ·
áC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\ClientApplicationUtilUpdateRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class .
"ClientApplicationUtilUpdateRequest 3
{ 
public 
string 
SpecialValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} í
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\EntityClaimUpdateRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
EntityClaimRequest #
{ 
public 
bool 
	CanSelect 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 ò
jC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\Login.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
Login 
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
UserPassword "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string !
ClientApplicationCode +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string %
ClientApplicationPassword /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
}		 
} À
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\RoleClaimRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
RoleClaimRequest !
{ 
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
ClaimId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ≈

{C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\RoleEntityClaimRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class "
RoleEntityClaimRequest '
{ 
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
string		 
Entity		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
bool

 
	CanSelect

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} Õ
pC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\RoleRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
RoleRequest 
{ 
public 
string 
RoleName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
}		 À
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\UserClaimRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
UserClaimRequest !
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
ClaimId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ≈

{C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\UserEntityClaimRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class "
UserEntityClaimRequest '
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public		 
string		 
Entity		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
bool

 
	CanSelect

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} É
pC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\UserRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
UserRequest 
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
bool 
EmailConfirmed "
{# $
get% (
;( )
set* -
;- .
}/ 0
}		 
}

 »
tC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\UserRoleRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
UserRoleRequest  
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
} 
} —
tC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\UserUtilRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class 
UserUtilRequest  
{ 
public 
string 
SpecialValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
} 
} ∆
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Request\UserUtilUpdateRequest.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Request4 ;
{ 
public 

class !
UserUtilUpdateRequest &
{ 
public 
string 
SpecialValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
}  
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\ClaimResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
ClaimResponse 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
CustomCLaim !
{" #
get$ '
;' (
set) ,
;, -
}. /
}		 
}

 ï
C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\ClientApplicationResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class %
ClientApplicationResponse *
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string !
ClientApplicationName +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string !
ClientApplicationCode +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
}		 ‚
wC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\RoleClaimResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
RoleClaimResponse "
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
ClaimId 
{ 
get  
;  !
set" %
;% &
}' (
} 
}		 ‹
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\RoleEntityClaimResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class #
RoleEntityClaimResponse (
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public		 
int		 
RoleId		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
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
public 
bool 
	CanSelect 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ‰
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\RoleResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
RoleResponse 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
RoleName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
}		 
}

 †
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\TokenResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
TokenResponse 
{ 
public 
string 
Token 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
ExpireInMinutes "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
DateTime		 
RequestUtcDateTime		 *
{		+ ,
get		- 0
;		0 1
set		2 5
;		5 6
}		7 8
public

 
DateTime

 
ExpireUtcDateTime

 )
{

* +
get

, /
;

/ 0
set

1 4
;

4 5
}

6 7
} 
} ‚
wC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\UserClaimResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
UserClaimResponse "
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
ClaimId 
{ 
get  
;  !
set" %
;% &
}' (
} 
}		 ‹
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\UserEntityClaimResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class #
UserEntityClaimResponse (
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public		 
int		 
UserId		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
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
public 
bool 
	CanSelect 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanCreate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanUpdate 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
	CanDelete 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ∞	
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\UserResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
UserResponse 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
Email		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
int 
? 

CustomerId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 
? 
PersonId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ﬂ
vC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Response\UserRoleResponse.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Response4 <
{ 
public 

class 
UserRoleResponse !
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
} 
}		 ò
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Utils\ApiRequestAccessor.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Utils4 9
{ 
public 

class 
ApiRequestAccessor #
:$ %
IApiRequestAccessor& 9
{		 
private

 
readonly

  
IHttpContextAccessor

 -
	_accessor

. 7
;

7 8
public 
ApiRequestAccessor !
(! " 
IHttpContextAccessor" 6
accessor7 ?
)? @
{ 	
	_accessor 
= 
accessor  
;  !
} 	
public 
T 
GetApiRequest 
< 
T  
>  !
(! "
)" #
{ 	
var 
apiRequestJson 
=  
	_accessor! *
.* +
HttpContext+ 6
.6 7
User7 ;
.; <
Claims< B
.B C
FirstOrDefaultC Q
(Q R
pR S
=>T V
pW X
.X Y
TypeY ]
==^ `
typeofa g
(g h
IApiRequesth s
)s t
.t u
Nameu y
)y z
?z {
.{ |
Value	| Å
;
Å Ç
return 
string 
. 
IsNullOrEmpty '
(' (
apiRequestJson( 6
)6 7
? 
default 
( 
T 
) 
: 
JsonConvert 
. 
DeserializeObject /
</ 0
T0 1
>1 2
(2 3
apiRequestJson3 A
)A B
;B C
} 	
} 
} ¶
vC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Utils\IApiRequestAccessor.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Utils4 9
{ 
public 

	interface 
IApiRequestAccessor (
{ 
T 	
GetApiRequest
 
< 
T 
> 
( 
) 
; 
} 
} •
iC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Utils\IToken.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Utils4 9
{ 
public 

	interface 
IToken 
{ 
string 
Issuer 
{ 
get 
; 
set  
;  !
}" #
string 
Audience 
{ 
get 
; 
set "
;" #
}$ %
string 
Key 
{ 
get 
; 
set 
; 
}  
int 
ExpireInMinutes 
{ 
get !
;! "
set# &
;& '
}( )
}		 
}

 í
hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Utils\Token.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4
Utils4 9
{ 
public 

class 
Token 
: 
IToken 
{ 
public 
string 
Issuer 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Audience 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Key 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
ExpireInMinutes "
{# $
get% (
;( )
set* -
;- .
}/ 0
}		 
}

 ó	
vC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\ClaimValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public 

class 
ClaimValidator 
:  !
AbstractValidator" 3
<3 4
ClaimRequest4 @
>@ A
{		 
public

 
ClaimValidator

 
(

 
)

 
{ 	
RuleFor 
( 
x 
=> 
x 
. 
CustomClaim &
)& '
.' (
NotEmpty( 0
(0 1
)1 2
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
CustomClaim` k
}k l
"l m
)m n
;n o
} 	
} 
} ”
ÇC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\ClientApplicationValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 &
ClientApplicationValidator		 +
:		, -
AbstractValidator		. ?
<		? @$
ClientApplicationRequest		@ X
>		X Y
{

 
public &
ClientApplicationValidator )
() *
)* +
{ 	
RuleFor 
( 
x 
=> 
x 
. !
ClientApplicationCode 0
)0 1
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$" 
{ 
ValidatorConstants )
.) *
CannotBeNullError* ;
}; <
 : < ?
{? @"
AuthorizationConstants@ V
.V W!
ClientApplicationCodeW l
}l m
"m n
)n o
. 
MaximumLength 
( 
$num  
)  !
. 
WithMessage 
( 
$" 
{ 
ValidatorConstants )
.) *
MaxLengthError* 8
}8 9
 : 9 <
{< ="
AuthorizationConstants= S
.S T!
ClientApplicationCodeT i
}i j
, 6j m
"m n
)n o
;o p
RuleFor 
( 
x 
=> 
x 
. !
ClientApplicationName 0
)0 1
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$" 
{ 
ValidatorConstants )
.) *
CannotBeNullError* ;
}; <
 : < ?
{? @"
AuthorizationConstants@ V
.V W!
ClientApplicationNameW l
}l m
"m n
)n o
. 
MaximumLength 
( 
$num !
)! "
. 
WithMessage 
( 
$" 
{ 
ValidatorConstants )
.) *
MaxLengthError* 8
}8 9
 : 9 <
{< ="
AuthorizationConstants= S
.S T!
ClientApplicationNameT i
}i j
, 20j n
"n o
)o p
;p q
RuleFor 
( 
x 
=> 
x 
. %
ClientApplicationPassword 4
)4 5
.5 6
NotEmpty6 >
(> ?
)? @
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `!
ClientApplicationPass` u
}u v
"v w
)w x
;x y
} 	
} 
} º
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\RoleClaimValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 
RoleClaimValidator		 #
:		$ %
AbstractValidator		& 7
<		7 8
RoleClaimRequest		8 H
>		H I
{

 
public 
RoleClaimValidator !
(! "
)" #
{ 	
RuleFor 
( 
x 
=> 
x 
. 
RoleId !
)! "
." #
NotEmpty# +
(+ ,
), -
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
RoleId` f
}f g
"g h
)h i
;i j
RuleFor 
( 
x 
=> 
x 
. 
ClaimId "
)" #
.# $
NotEmpty$ ,
(, -
)- .
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
ClaimId` g
}g h
"h i
)i j
;j k
} 	
} 
} É
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\RoleEntityClaimValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 $
RoleEntityClaimValidator		 )
:		* +
AbstractValidator		, =
<		= >"
RoleEntityClaimRequest		> T
>		T U
{

 
public $
RoleEntityClaimValidator '
(' (
)( )
{ 	
RuleFor 
( 
x 
=> 
x 
. 
RoleId !
)! "
." #
NotEmpty# +
(+ ,
), -
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
RoleId` f
}f g
"g h
)h i
;i j
RuleFor 
( 
x 
=> 
x 
. 
Entity !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$"( *
{* +
ValidatorConstants+ =
.= >
CannotBeNullError> O
}O P
 : P S
{S T"
AuthorizationConstantsT j
.j k
Entityk q
}q r
"r s
)s t
. 
MaximumLength 
( 
$num !
)! "
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
MaxLengthError3 A
}A B
 : B E
{E F"
AuthorizationConstantsF \
.\ ]
Entity] c
}c d
, 50d h
"h i
)i j
;j k
} 	
} 
} ú
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\RoleValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 
RoleValidator		 
:		  
AbstractValidator		! 2
<		2 3
RoleRequest		3 >
>		> ?
{

 
public 
RoleValidator 
( 
) 
{ 	
RuleFor 
( 
x 
=> 
x 
. 
RoleName #
)# $
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$"( *
{* +
ValidatorConstants+ =
.= >
CannotBeNullError> O
}O P
 : P S
{S T"
AuthorizationConstantsT j
.j k
RoleNamek s
}s t
"t u
)u v
. 
MaximumLength 
( 
$num !
)! "
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
MaxLengthError3 A
}A B
 : B E
{E F"
AuthorizationConstantsF \
.\ ]
RoleName] e
}e f
, 25f j
"j k
)k l
;l m
RuleFor 
( 
x 
=> 
x 
. 
Description &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$" 
{ 
ValidatorConstants )
.) *
CannotBeNullError* ;
}; <
 : < ?
{? @"
AuthorizationConstants@ V
.V W
DescriptionW b
}b c
"c d
)d e
. 
MaximumLength 
( 
$num "
)" #
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
MaxLengthError3 A
}A B
 : B E
{E F"
AuthorizationConstantsF \
.\ ]
Description] h
}h i
, 255i n
"n o
)o p
;p q
} 	
} 
} º
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\UserClaimValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 
UserClaimValidator		 #
:		$ %
AbstractValidator		& 7
<		7 8
UserClaimRequest		8 H
>		H I
{

 
public 
UserClaimValidator !
(! "
)" #
{ 	
RuleFor 
( 
x 
=> 
x 
. 
UserId !
)! "
." #
NotEmpty# +
(+ ,
), -
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
UserId` f
}f g
"g h
)h i
;i j
RuleFor 
( 
x 
=> 
x 
. 
ClaimId "
)" #
.# $
NotEmpty$ ,
(, -
)- .
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
ClaimId` g
}g h
"h i
)i j
;j k
} 	
} 
} É
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\UserEntityClaimValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 $
UserEntityClaimValidator		 )
:		* +
AbstractValidator		, =
<		= >"
UserEntityClaimRequest		> T
>		T U
{

 
public $
UserEntityClaimValidator '
(' (
)( )
{ 	
RuleFor 
( 
x 
=> 
x 
. 
UserId !
)! "
." #
NotEmpty# +
(+ ,
), -
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
UserId` f
}f g
"g h
)h i
;i j
RuleFor 
( 
x 
=> 
x 
. 
Entity !
)! "
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$"( *
{* +
ValidatorConstants+ =
.= >
CannotBeNullError> O
}O P
 : P S
{S T"
AuthorizationConstantsT j
.j k
Entityk q
}q r
"r s
)s t
. 
MaximumLength 
( 
$num !
)! "
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
MaxLengthError3 A
}A B
 : B E
{E F"
AuthorizationConstantsF \
.\ ]
Entity] c
}c d
, 50d h
"h i
)i j
;j k
} 	
} 
} ∂
yC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\UserRoleValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 
UserRoleValidator		 "
:		# $
AbstractValidator		% 6
<		6 7
UserRoleRequest		7 F
>		F G
{

 
public 
UserRoleValidator  
(  !
)! "
{ 	
RuleFor 
( 
x 
=> 
x 
. 
UserId !
)! "
." #
NotEmpty# +
(+ ,
), -
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
UserId` f
}f g
"g h
)h i
;i j
RuleFor 
( 
x 
=> 
x 
. 
RoleId !
)! "
." #
NotEmpty# +
(+ ,
), -
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
RoleId` f
}f g
"g h
)h i
;i j
} 	
} 
} æ
uC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.WebApiUtils.Authorization\Validators\UserValidator.cs
	namespace 	
CustomFramework
 
. 
WebApiUtils %
.% &
Authorization& 3
.3 4

Validators4 >
{ 
public		 

class		 
UserValidator		 
:		  
AbstractValidator		! 2
<		2 3
UserRequest		3 >
>		> ?
{

 
public 
UserValidator 
( 
) 
{ 	
RuleFor 
( 
x 
=> 
x 
. 
UserName #
)# $
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$"( *
{* +
ValidatorConstants+ =
.= >
CannotBeNullError> O
}O P
 : P S
{S T"
AuthorizationConstantsT j
.j k
UserNamek s
}s t
"t u
)u v
. 
MaximumLength 
( 
$num !
)! "
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
MaxLengthError3 A
}A B
 : B E
{E F"
AuthorizationConstantsF \
.\ ]
UserName] e
}e f
, 25f j
"j k
)k l
;l m
RuleFor 
( 
x 
=> 
x 
. 
Password #
)# $
.$ %
NotEmpty% -
(- .
). /
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
CannotBeNullError3 D
}D E
 : E H
{H I"
AuthorizationConstantsI _
._ `
Pass` d
}d e
"e f
)f g
;g h
RuleFor 
( 
x 
=> 
x 
. 
Email  
)  !
. 
NotEmpty 
( 
) 
. 
WithMessage '
(' (
$"( *
{* +
ValidatorConstants+ =
.= >
CannotBeNullError> O
}O P
 : P S
{S T"
AuthorizationConstantsT j
.j k
Emailk p
}p q
"q r
)r s
. 
MaximumLength 
( 
$num "
)" #
. 
WithMessage 
( 
$" 
{  
ValidatorConstants  2
.2 3
MaxLengthError3 A
}A B
 : B E
{E F"
AuthorizationConstantsF \
.\ ]
Email] b
}b c
, 100c h
"h i
)i j
. 
EmailAddress 
( 
) 
.  
WithMessage  +
(+ ,
$", .
{. /
ValidatorConstants/ A
.A B
EmailFormatErrorB R
}R S
"S T
)T U
;U V
} 	
} 
} 