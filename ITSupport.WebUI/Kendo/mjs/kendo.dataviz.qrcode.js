/**
 * Kendo UI v2023.1.314 (http://www.telerik.com/kendo-ui)
 * Copyright 2023 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.dataviz.core.js";import"./kendo.drawing.js";var __meta__={id:"dataviz.qrcode",name:"QRCode",category:"dataviz",description:"QRCode widget.",depends:["dataviz.core","drawing"]};!function(o,r){var e=window.kendo,t=o.extend,d=e.drawing,a=e.dataviz,s=e.ui.Widget,n=a.Box2D,l="0000",u="numeric",i="alphanumeric",w="byte",C={1:0},g={0:1},c=[[1,0],[1,25,0]],h={15:20,16:20,18:24,19:24,22:20,24:22,26:24,28:20,30:20,31:24,32:28,33:24,36:18,37:22,39:20,40:24},p=[{L:{groups:[[1,19]],totalDataCodewords:19,errorCodewordsPerBlock:7},M:{groups:[[1,16]],totalDataCodewords:16,errorCodewordsPerBlock:10},Q:{groups:[[1,13]],totalDataCodewords:13,errorCodewordsPerBlock:13},H:{groups:[[1,9]],totalDataCodewords:9,errorCodewordsPerBlock:17}},{L:{groups:[[1,34]],totalDataCodewords:34,errorCodewordsPerBlock:10},M:{groups:[[1,28]],totalDataCodewords:28,errorCodewordsPerBlock:16},Q:{groups:[[1,22]],totalDataCodewords:22,errorCodewordsPerBlock:22},H:{groups:[[1,16]],totalDataCodewords:16,errorCodewordsPerBlock:28}},{L:{groups:[[1,55]],totalDataCodewords:55,errorCodewordsPerBlock:15},M:{groups:[[1,44]],totalDataCodewords:44,errorCodewordsPerBlock:26},Q:{groups:[[2,17]],totalDataCodewords:34,errorCodewordsPerBlock:18},H:{groups:[[2,13]],totalDataCodewords:26,errorCodewordsPerBlock:22}},{L:{groups:[[1,80]],totalDataCodewords:80,errorCodewordsPerBlock:20},M:{groups:[[2,32]],totalDataCodewords:64,errorCodewordsPerBlock:18},Q:{groups:[[2,24]],totalDataCodewords:48,errorCodewordsPerBlock:26},H:{groups:[[4,9]],totalDataCodewords:36,errorCodewordsPerBlock:16}},{L:{groups:[[1,108]],totalDataCodewords:108,errorCodewordsPerBlock:26},M:{groups:[[2,43]],totalDataCodewords:86,errorCodewordsPerBlock:24},Q:{groups:[[2,15],[2,16]],totalDataCodewords:62,errorCodewordsPerBlock:18},H:{groups:[[2,11],[2,12]],totalDataCodewords:46,errorCodewordsPerBlock:22}},{L:{groups:[[2,68]],totalDataCodewords:136,errorCodewordsPerBlock:18},M:{groups:[[4,27]],totalDataCodewords:108,errorCodewordsPerBlock:16},Q:{groups:[[4,19]],totalDataCodewords:76,errorCodewordsPerBlock:24},H:{groups:[[4,15]],totalDataCodewords:60,errorCodewordsPerBlock:28}},{L:{groups:[[2,78]],totalDataCodewords:156,errorCodewordsPerBlock:20},M:{groups:[[4,31]],totalDataCodewords:124,errorCodewordsPerBlock:18},Q:{groups:[[2,14],[4,15]],totalDataCodewords:88,errorCodewordsPerBlock:18},H:{groups:[[4,13],[1,14]],totalDataCodewords:66,errorCodewordsPerBlock:26}},{L:{groups:[[2,97]],totalDataCodewords:194,errorCodewordsPerBlock:24},M:{groups:[[2,38],[2,39]],totalDataCodewords:154,errorCodewordsPerBlock:22},Q:{groups:[[4,18],[2,19]],totalDataCodewords:110,errorCodewordsPerBlock:22},H:{groups:[[4,14],[2,15]],totalDataCodewords:86,errorCodewordsPerBlock:26}},{L:{groups:[[2,116]],totalDataCodewords:232,errorCodewordsPerBlock:30},M:{groups:[[3,36],[2,37]],totalDataCodewords:182,errorCodewordsPerBlock:22},Q:{groups:[[4,16],[4,17]],totalDataCodewords:132,errorCodewordsPerBlock:20},H:{groups:[[4,12],[4,13]],totalDataCodewords:100,errorCodewordsPerBlock:24}},{L:{groups:[[2,68],[2,69]],totalDataCodewords:274,errorCodewordsPerBlock:18},M:{groups:[[4,43],[1,44]],totalDataCodewords:216,errorCodewordsPerBlock:26},Q:{groups:[[6,19],[2,20]],totalDataCodewords:154,errorCodewordsPerBlock:24},H:{groups:[[6,15],[2,16]],totalDataCodewords:122,errorCodewordsPerBlock:28}},{L:{groups:[[4,81]],totalDataCodewords:324,errorCodewordsPerBlock:20},M:{groups:[[1,50],[4,51]],totalDataCodewords:254,errorCodewordsPerBlock:30},Q:{groups:[[4,22],[4,23]],totalDataCodewords:180,errorCodewordsPerBlock:28},H:{groups:[[3,12],[8,13]],totalDataCodewords:140,errorCodewordsPerBlock:24}},{L:{groups:[[2,92],[2,93]],totalDataCodewords:370,errorCodewordsPerBlock:24},M:{groups:[[6,36],[2,37]],totalDataCodewords:290,errorCodewordsPerBlock:22},Q:{groups:[[4,20],[6,21]],totalDataCodewords:206,errorCodewordsPerBlock:26},H:{groups:[[7,14],[4,15]],totalDataCodewords:158,errorCodewordsPerBlock:28}},{L:{groups:[[4,107]],totalDataCodewords:428,errorCodewordsPerBlock:26},M:{groups:[[8,37],[1,38]],totalDataCodewords:334,errorCodewordsPerBlock:22},Q:{groups:[[8,20],[4,21]],totalDataCodewords:244,errorCodewordsPerBlock:24},H:{groups:[[12,11],[4,12]],totalDataCodewords:180,errorCodewordsPerBlock:22}},{L:{groups:[[3,115],[1,116]],totalDataCodewords:461,errorCodewordsPerBlock:30},M:{groups:[[4,40],[5,41]],totalDataCodewords:365,errorCodewordsPerBlock:24},Q:{groups:[[11,16],[5,17]],totalDataCodewords:261,errorCodewordsPerBlock:20},H:{groups:[[11,12],[5,13]],totalDataCodewords:197,errorCodewordsPerBlock:24}},{L:{groups:[[5,87],[1,88]],totalDataCodewords:523,errorCodewordsPerBlock:22},M:{groups:[[5,41],[5,42]],totalDataCodewords:415,errorCodewordsPerBlock:24},Q:{groups:[[5,24],[7,25]],totalDataCodewords:295,errorCodewordsPerBlock:30},H:{groups:[[11,12],[7,13]],totalDataCodewords:223,errorCodewordsPerBlock:24}},{L:{groups:[[5,98],[1,99]],totalDataCodewords:589,errorCodewordsPerBlock:24},M:{groups:[[7,45],[3,46]],totalDataCodewords:453,errorCodewordsPerBlock:28},Q:{groups:[[15,19],[2,20]],totalDataCodewords:325,errorCodewordsPerBlock:24},H:{groups:[[3,15],[13,16]],totalDataCodewords:253,errorCodewordsPerBlock:30}},{L:{groups:[[1,107],[5,108]],totalDataCodewords:647,errorCodewordsPerBlock:28},M:{groups:[[10,46],[1,47]],totalDataCodewords:507,errorCodewordsPerBlock:28},Q:{groups:[[1,22],[15,23]],totalDataCodewords:367,errorCodewordsPerBlock:28},H:{groups:[[2,14],[17,15]],totalDataCodewords:283,errorCodewordsPerBlock:28}},{L:{groups:[[5,120],[1,121]],totalDataCodewords:721,errorCodewordsPerBlock:30},M:{groups:[[9,43],[4,44]],totalDataCodewords:563,errorCodewordsPerBlock:26},Q:{groups:[[17,22],[1,23]],totalDataCodewords:397,errorCodewordsPerBlock:28},H:{groups:[[2,14],[19,15]],totalDataCodewords:313,errorCodewordsPerBlock:28}},{L:{groups:[[3,113],[4,114]],totalDataCodewords:795,errorCodewordsPerBlock:28},M:{groups:[[3,44],[11,45]],totalDataCodewords:627,errorCodewordsPerBlock:26},Q:{groups:[[17,21],[4,22]],totalDataCodewords:445,errorCodewordsPerBlock:26},H:{groups:[[9,13],[16,14]],totalDataCodewords:341,errorCodewordsPerBlock:26}},{L:{groups:[[3,107],[5,108]],totalDataCodewords:861,errorCodewordsPerBlock:28},M:{groups:[[3,41],[13,42]],totalDataCodewords:669,errorCodewordsPerBlock:26},Q:{groups:[[15,24],[5,25]],totalDataCodewords:485,errorCodewordsPerBlock:30},H:{groups:[[15,15],[10,16]],totalDataCodewords:385,errorCodewordsPerBlock:28}},{L:{groups:[[4,116],[4,117]],totalDataCodewords:932,errorCodewordsPerBlock:28},M:{groups:[[17,42]],totalDataCodewords:714,errorCodewordsPerBlock:26},Q:{groups:[[17,22],[6,23]],totalDataCodewords:512,errorCodewordsPerBlock:28},H:{groups:[[19,16],[6,17]],totalDataCodewords:406,errorCodewordsPerBlock:30}},{L:{groups:[[2,111],[7,112]],totalDataCodewords:1006,errorCodewordsPerBlock:28},M:{groups:[[17,46]],totalDataCodewords:782,errorCodewordsPerBlock:28},Q:{groups:[[7,24],[16,25]],totalDataCodewords:568,errorCodewordsPerBlock:30},H:{groups:[[34,13]],totalDataCodewords:442,errorCodewordsPerBlock:24}},{L:{groups:[[4,121],[5,122]],totalDataCodewords:1094,errorCodewordsPerBlock:30},M:{groups:[[4,47],[14,48]],totalDataCodewords:860,errorCodewordsPerBlock:28},Q:{groups:[[11,24],[14,25]],totalDataCodewords:614,errorCodewordsPerBlock:30},H:{groups:[[16,15],[14,16]],totalDataCodewords:464,errorCodewordsPerBlock:30}},{L:{groups:[[6,117],[4,118]],totalDataCodewords:1174,errorCodewordsPerBlock:30},M:{groups:[[6,45],[14,46]],totalDataCodewords:914,errorCodewordsPerBlock:28},Q:{groups:[[11,24],[16,25]],totalDataCodewords:664,errorCodewordsPerBlock:30},H:{groups:[[30,16],[2,17]],totalDataCodewords:514,errorCodewordsPerBlock:30}},{L:{groups:[[8,106],[4,107]],totalDataCodewords:1276,errorCodewordsPerBlock:26},M:{groups:[[8,47],[13,48]],totalDataCodewords:1e3,errorCodewordsPerBlock:28},Q:{groups:[[7,24],[22,25]],totalDataCodewords:718,errorCodewordsPerBlock:30},H:{groups:[[22,15],[13,16]],totalDataCodewords:538,errorCodewordsPerBlock:30}},{L:{groups:[[10,114],[2,115]],totalDataCodewords:1370,errorCodewordsPerBlock:28},M:{groups:[[19,46],[4,47]],totalDataCodewords:1062,errorCodewordsPerBlock:28},Q:{groups:[[28,22],[6,23]],totalDataCodewords:754,errorCodewordsPerBlock:28},H:{groups:[[33,16],[4,17]],totalDataCodewords:596,errorCodewordsPerBlock:30}},{L:{groups:[[8,122],[4,123]],totalDataCodewords:1468,errorCodewordsPerBlock:30},M:{groups:[[22,45],[3,46]],totalDataCodewords:1128,errorCodewordsPerBlock:28},Q:{groups:[[8,23],[26,24]],totalDataCodewords:808,errorCodewordsPerBlock:30},H:{groups:[[12,15],[28,16]],totalDataCodewords:628,errorCodewordsPerBlock:30}},{L:{groups:[[3,117],[10,118]],totalDataCodewords:1531,errorCodewordsPerBlock:30},M:{groups:[[3,45],[23,46]],totalDataCodewords:1193,errorCodewordsPerBlock:28},Q:{groups:[[4,24],[31,25]],totalDataCodewords:871,errorCodewordsPerBlock:30},H:{groups:[[11,15],[31,16]],totalDataCodewords:661,errorCodewordsPerBlock:30}},{L:{groups:[[7,116],[7,117]],totalDataCodewords:1631,errorCodewordsPerBlock:30},M:{groups:[[21,45],[7,46]],totalDataCodewords:1267,errorCodewordsPerBlock:28},Q:{groups:[[1,23],[37,24]],totalDataCodewords:911,errorCodewordsPerBlock:30},H:{groups:[[19,15],[26,16]],totalDataCodewords:701,errorCodewordsPerBlock:30}},{L:{groups:[[5,115],[10,116]],totalDataCodewords:1735,errorCodewordsPerBlock:30},M:{groups:[[19,47],[10,48]],totalDataCodewords:1373,errorCodewordsPerBlock:28},Q:{groups:[[15,24],[25,25]],totalDataCodewords:985,errorCodewordsPerBlock:30},H:{groups:[[23,15],[25,16]],totalDataCodewords:745,errorCodewordsPerBlock:30}},{L:{groups:[[13,115],[3,116]],totalDataCodewords:1843,errorCodewordsPerBlock:30},M:{groups:[[2,46],[29,47]],totalDataCodewords:1455,errorCodewordsPerBlock:28},Q:{groups:[[42,24],[1,25]],totalDataCodewords:1033,errorCodewordsPerBlock:30},H:{groups:[[23,15],[28,16]],totalDataCodewords:793,errorCodewordsPerBlock:30}},{L:{groups:[[17,115]],totalDataCodewords:1955,errorCodewordsPerBlock:30},M:{groups:[[10,46],[23,47]],totalDataCodewords:1541,errorCodewordsPerBlock:28},Q:{groups:[[10,24],[35,25]],totalDataCodewords:1115,errorCodewordsPerBlock:30},H:{groups:[[19,15],[35,16]],totalDataCodewords:845,errorCodewordsPerBlock:30}},{L:{groups:[[17,115],[1,116]],totalDataCodewords:2071,errorCodewordsPerBlock:30},M:{groups:[[14,46],[21,47]],totalDataCodewords:1631,errorCodewordsPerBlock:28},Q:{groups:[[29,24],[19,25]],totalDataCodewords:1171,errorCodewordsPerBlock:30},H:{groups:[[11,15],[46,16]],totalDataCodewords:901,errorCodewordsPerBlock:30}},{L:{groups:[[13,115],[6,116]],totalDataCodewords:2191,errorCodewordsPerBlock:30},M:{groups:[[14,46],[23,47]],totalDataCodewords:1725,errorCodewordsPerBlock:28},Q:{groups:[[44,24],[7,25]],totalDataCodewords:1231,errorCodewordsPerBlock:30},H:{groups:[[59,16],[1,17]],totalDataCodewords:961,errorCodewordsPerBlock:30}},{L:{groups:[[12,121],[7,122]],totalDataCodewords:2306,errorCodewordsPerBlock:30},M:{groups:[[12,47],[26,48]],totalDataCodewords:1812,errorCodewordsPerBlock:28},Q:{groups:[[39,24],[14,25]],totalDataCodewords:1286,errorCodewordsPerBlock:30},H:{groups:[[22,15],[41,16]],totalDataCodewords:986,errorCodewordsPerBlock:30}},{L:{groups:[[6,121],[14,122]],totalDataCodewords:2434,errorCodewordsPerBlock:30},M:{groups:[[6,47],[34,48]],totalDataCodewords:1914,errorCodewordsPerBlock:28},Q:{groups:[[46,24],[10,25]],totalDataCodewords:1354,errorCodewordsPerBlock:30},H:{groups:[[2,15],[64,16]],totalDataCodewords:1054,errorCodewordsPerBlock:30}},{L:{groups:[[17,122],[4,123]],totalDataCodewords:2566,errorCodewordsPerBlock:30},M:{groups:[[29,46],[14,47]],totalDataCodewords:1992,errorCodewordsPerBlock:28},Q:{groups:[[49,24],[10,25]],totalDataCodewords:1426,errorCodewordsPerBlock:30},H:{groups:[[24,15],[46,16]],totalDataCodewords:1096,errorCodewordsPerBlock:30}},{L:{groups:[[4,122],[18,123]],totalDataCodewords:2702,errorCodewordsPerBlock:30},M:{groups:[[13,46],[32,47]],totalDataCodewords:2102,errorCodewordsPerBlock:28},Q:{groups:[[48,24],[14,25]],totalDataCodewords:1502,errorCodewordsPerBlock:30},H:{groups:[[42,15],[32,16]],totalDataCodewords:1142,errorCodewordsPerBlock:30}},{L:{groups:[[20,117],[4,118]],totalDataCodewords:2812,errorCodewordsPerBlock:30},M:{groups:[[40,47],[7,48]],totalDataCodewords:2216,errorCodewordsPerBlock:28},Q:{groups:[[43,24],[22,25]],totalDataCodewords:1582,errorCodewordsPerBlock:30},H:{groups:[[10,15],[67,16]],totalDataCodewords:1222,errorCodewordsPerBlock:30}},{L:{groups:[[19,118],[6,119]],totalDataCodewords:2956,errorCodewordsPerBlock:30},M:{groups:[[18,47],[31,48]],totalDataCodewords:2334,errorCodewordsPerBlock:28},Q:{groups:[[34,24],[34,25]],totalDataCodewords:1666,errorCodewordsPerBlock:30},H:{groups:[[20,15],[61,16]],totalDataCodewords:1276,errorCodewordsPerBlock:30}}],f=[1,0,1,1,1],B=[1,0,1],D={L:"01",M:"00",Q:"11",H:"10"},k=["11101100","00010001"],P=[function(o,r){return(o+r)%2==0},function(o){return o%2==0},function(o,r){return r%3==0},function(o,r){return(o+r)%3==0},function(o,r){return(Math.floor(o/2)+Math.floor(r/3))%2==0},function(o,r){return o*r%2+o*r%3==0},function(o,r){return(o*r%2+o*r%3)%2==0},function(o,r){return((o+r)%2+o*r%3)%2==0}],v=/^\d+/,M=new RegExp("^[A-Z $%*+./:-]+"),m=new RegExp("^[A-Z0-9 $%*+./:-]+"),L=new RegExp("^[^A-Z0-9 $%*+./:-]+"),_=Math.round,S=[[0,1],[1,1],[1,2],[2,2],[2,1],[3,1],[3,0],[2,0],[2,-1],[1,-1],[1,0]],Q=[[0,1],[1,1],[1,0]];function A(o){return parseInt(o,2)}function H(o,r){var e=Number(o).toString(2);return e.length<r&&(e=new Array(r-e.length+1).join(0)+e),e}function E(o,r){for(var e=[],t=0;t<o.length;)e.push(o.substring(t,t+r)),t+=r;return e}var I=e.Class.extend({getVersionIndex:function(o){return o<10?0:o>26?2:1},getBitsCharacterCount:function(o){return this.bitsInCharacterCount[this.getVersionIndex(o||40)]},getModeCountString:function(o,r){return this.modeIndicator+H(o,this.getBitsCharacterCount(r))},encode:function(){},getStringBitsLength:function(){},getValue:function(){},modeIndicator:"",bitsInCharacterCount:[]}),x={};x.numeric=I.extend({bitsInCharacterCount:[10,12,14],modeIndicator:"0001",getValue:function(o){return parseInt(o,10)},encode:function(o,r){for(var e=E(o,3),t=this.getModeCountString(o.length,r),d=0;d<e.length-1;d++)t+=H(e[d],10);return t+H(e[d],1+3*e[d].length)},getStringBitsLength:function(o,r){var e=o%3;return 4+this.getBitsCharacterCount(r)+10*Math.floor(o/3)+3*e+(0===e?0:1)}}),x.alphanumeric=I.extend({characters:{0:0,1:1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:9,A:10,B:11,C:12,D:13,E:14,F:15,G:16,H:17,I:18,J:19,K:20,L:21,M:22,N:23,O:24,P:25,Q:26,R:27,S:28,T:29,U:30,V:31,W:32,X:33,Y:34,Z:35," ":36,$:37,"%":38,"*":39,"+":40,"-":41,".":42,"/":43,":":44},bitsInCharacterCount:[9,11,13],modeIndicator:"0010",getValue:function(o){return this.characters[o]},encode:function(o,r){for(var e=this,t=E(o,2),d=e.getModeCountString(o.length,r),a=0;a<t.length-1;a++)d+=H(45*e.getValue(t[a].charAt(0))+e.getValue(t[a].charAt(1)),11);return d+H(2==t[a].length?45*e.getValue(t[a].charAt(0))+e.getValue(t[a].charAt(1)):e.getValue(t[a].charAt(0)),1+5*t[a].length)},getStringBitsLength:function(o,r){return 4+this.getBitsCharacterCount(r)+11*Math.floor(o/2)+o%2*6}}),x.byte=I.extend({bitsInCharacterCount:[8,16,16],modeIndicator:"0100",getValue:function(o){var r=o.charCodeAt(0);if(r<=127||160<=r&&r<=255)return r;throw new Error("Unsupported character: "+o)},encode:function(o,r){for(var e=this.getModeCountString(o.length,r),t=0;t<o.length;t++)e+=H(this.getValue(o.charAt(t)),8);return e},getStringBitsLength:function(o,r){return 4+this.getBitsCharacterCount(r)+8*o}});var y={};for(var R in x)y[R]=new x[R];var T=function(o){var e=this,t=o.length-1,d=o.length-1,a=d,s=-1,n=0;e.move=function(){t+=s*n,d=a-(n^=1)},e.getNextCell=function(){for(;o[t][d]!==r;)e.move(),(t<0||t>=o.length)&&(d=a-=8!=a?2:3,t=(s=-s)<0?o.length-1:0);return{row:t,column:d}},e.getNextRemainderCell=function(){if(e.move(),o[t][d]===r)return{row:t,column:d}}};function U(o,r,e,t){for(var d=0;d<o.length;d++)o[d][e][t]=r}function O(o,r,e,t){for(var d=0;d<P.length;d++)o[d][e][t]=P[d](e,t)?1^r:parseInt(r,10)}var V=function(o,r){for(var e,t,d,a=new T(o[0]),s=0;s<r.length;s++)for(e=r[s],t=0;e.length>0;){for(var n=0;n<e.length;n++)for(var l=0;l<8;l++)d=a.getNextCell(),O(o,e[n][t].charAt(l),d.row,d.column);for(t++;e[0]&&t==e[0].length;)e.splice(0,1)}for(;d=a.getNextRemainderCell();)O(o,0,d.row,d.column)},b=function(o,r){for(var e=8*r,t=0,d=0;o.length<e&&t<l.length;)o+=l.charAt(t++);for(o.length%8!=0&&(o+=new Array(9-o.length%8).join("0"));o.length<e;)o+=k[d],d^=1;return o};var z=function(o,r){for(var e=[],t=o.length-2;t>=0;t--)e[t]=o[t]^r[t];return e},N=function(o,e){for(var t=[],d=0;d<o.length;d++)for(var a=0;a<e.length;a++)t[d+a]===r?t[d+a]=(o[d]+(e[a]>=0?e[a]:0))%255:t[d+a]=C[g[t[d+a]]^g[(o[d]+e[a])%255]];return t};function F(o,e){var t=[],d=o.length-1;do{t[d]=g[(o[d]+e)%255],d--}while(o[d]!==r);return t}!function(){for(var o,r=1;r<255;r++)(o=2*g[r-1])>255&&(o^=285),g[r]=o,C[o]=r;o=2*g[r-1]^285,g[r]=o,g[-1]=0}(),function(){for(var o=2;o<=68;o++){var r=c[o-1],e=[o,0];c[o]=N(r,e)}}();var Z=function(o,r){var e,t,d=c[r-1],a=new Array(r).concat(o),s=new Array(a.length-d.length).concat(d),n=o.length,l=[];for(t=0;t<n;t++)e=F(s,C[a[a.length-1]]),s.splice(0,1),a=z(e,a);for(t=a.length-1;t>=0;t--)l[r-1-t]=H(a[t],8);return l},G=function(o,r){for(var e,t,d,a,s,n=0,l=[],u=[],i=r.groups,w=0;w<i.length;w++){d=i[w][0];for(var C=0;C<d;C++){t=i[w][1],e=[],a=[];for(var g=1;g<=t;g++)s=o.substring(n,n+8),e.push(s),a[t-g]=A(s),n+=8;l.push(e),u.push(Z(a,r.errorCodewordsPerBlock))}}return[l,u]},j=function(o,r,e,t,d){var a,s,n=v.exec(o),l=n?n[0]:"",C=M.exec(o),g=C?C[0]:"",c=m.exec(o),h=c?c[0]:"";return l&&(l.length>=r||o.length==l.length||l.length>=e&&!m.test(o.charAt(l.length)))?(a=u,s=l):h&&(o.length==h.length||h.length>=t||d==i)?(a=i,s=l||g):(a=w,s=h?h+L.exec(o.substring(h.length))[0]:L.exec(o)[0]),{mode:a,modeString:s}},K=function(o){var r,e=[],t=0;for(e.push(j(o,8,5,8,r)),r=e[0].mode,o=o.substr(e[0].modeString.length);o.length>0;){var d=j(o,17,9,16,r);d.mode!=r?(r=d.mode,e.push(d),t++):e[t].modeString+=d.modeString,o=o.substr(d.modeString.length)}return e},W=function(o){for(var r=0,e=0;e<o.length;e++)r+=y[o[e].mode].getStringBitsLength(o[e].modeString.length);return Math.ceil(r/8)},$=function(o,r){var e=0,t=p.length-1,d=Math.floor(p.length/2);do{o<p[d][r].totalDataCodewords?t=d:e=d,d=e+Math.floor((t-e)/2)}while(t-e>1);return o<=p[e][r].totalDataCodewords?d+1:t+1},q=function(o,r){for(var e="",t=0;t<o.length;t++)e+=y[o[t].mode].encode(o[t].modeString,r);return e},X=function(o){var r,e="";if(0===A(o))return"101010000010010";r=J(A(o),"10100110111",15);for(var t=0;t<r.length;t++)e+=r.charAt(t)^"101010000010010".charAt(t);return e},J=function(o,r,e){var t=A(r),d=r.length-1,a=o<<d,s=H(o,e-d),n=Y(a,t);return n=s+H(n,d)},Y=function(o,r){var e=r.toString(2).length,t=o.toString(2).length;do{t=(o^=r<<t-e).toString(2).length}while(t>=e);return o};function oo(o,r){return parseInt(o.charAt(r),10)}var ro=function(o){for(var r=[],e=17+4*o,t=0;t<P.length;t++){r[t]=new Array(e);for(var d=0;d<e;d++)r[t][d]=new Array(e)}return r},eo=function(o,r){var e,t,d=o[0],a=0,s=r.length;for(e=0,t=8;e<=8;e++)6!==e&&U(o,oo(r,s-1-a++),e,t);for(e=8,t=7;t>=0;t--)6!==t&&U(o,oo(r,s-1-a++),e,t);for(a=0,t=d.length-1,e=8;t>=d.length-8;t--)U(o,oo(r,s-1-a++),e,t);for(U(o,1,d.length-8,8),e=d.length-7,t=8;e<d.length;e++)U(o,oo(r,s-1-a++),e,t)},to=function(o){return J(o,"1111100100101",18)},ao=function(o,r){for(var e,t,d,a=o[0].length,s=a-11,n=a-11,l=0;l<r.length;l++)e=Math.floor(l/3),t=l%3,U(o,d=oo(r,r.length-l-1),0+e,s+t),U(o,d,n+t,0+e)},so=function(o,r,e,t){for(var d,a=r.length+2,s=r.length+1,n=0;n<r.length;n++)for(var l=n;l<a-n;l++)U(o,d=r[n],e+l,t+n),U(o,d,e+n,t+l),U(o,d,e+s-l,t+s-n),U(o,d,e+s-n,t+s-l)},no=function(o,r,e,t){var d=e,a=t,s=o[0];do{U(o,0,d,t),U(o,0,e,a),d+=r[0],a+=r[1]}while(d>=0&&d<s.length)},lo=function(o){var r=o[0].length;so(o,f,0,0),no(o,[-1,-1],7,7),so(o,f,r-7,0),no(o,[1,-1],r-8,7),so(o,f,0,r-7),no(o,[-1,1],7,r-8)},uo=function(o,e){if(!(e<2)){var t,d,a=o[0],s=a.length,n=Math.floor(e/7),l=[6],u=0;for((t=h[e])?d=(s-13-t)/n:t=d=(s-13)/(n+1),l.push(l[u++]+t);l[u]+d<s;)l.push(l[u++]+d);for(var i=0;i<l.length;i++)for(var w=0;w<l.length;w++)a[l[i]][l[w]]===r&&so(o,B,l[i]-2,l[w]-2)}},io=function(o){for(var r=1,e=o[0].length,t=8;t<e-8;t++)U(o,r,6,t),U(o,r,t,6),r^=1},wo=function(o){var r,e,t=[],d=[],a=[],s=[],n=[],l=o[0].length;for(e=0;e<o.length;e++)t[e]=0,a[e]=0,n[e]=[0,0],s[e]=[0,0],d[e]=[];for(e=0;e<l;e++)for(var u=0;u<l;u++)for(var i=0;i<o.length;i++)r=o[i],a[i]+=parseInt(r[e][u],10),d[i][0]===r[e][u]&&e+1<l&&u-1>=0&&r[e+1][u]==d[i][0]&&r[e+1][u-1]==d[i][0]&&(t[i]+=3),Co(i,s,t,0,r[e][u]),Co(i,s,t,1,r[u][e]),go(i,t,d,r[e][u],n,0),go(i,t,d,r[u][e],n,1);var w,C=l*l,g=Number.MAX_VALUE;for(e=0;e<t.length;e++)t[e]+=co(a[e],C),t[e]<g&&(g=t[e],w=e);return w};function Co(o,r,e,t,d){r[o][t]=(r[o][t]<<1^d)%128,93==r[o][t]&&(e[o]+=40)}function go(o,r,e,t,d,a){e[o][a]==t?d[o][a]++:(e[o][a]=t,d[o][a]>=5&&(r[o]+=3+d[o][a]-5),d[o][a]=1)}function co(o,r){var e=Math.floor(o/r*100),t=e%5,d=Math.abs(e-t-50),a=Math.abs(e+5-t-50);return 10*Math.min(d/5,a/5)}var ho=function(o,r){this.dataString=o,this.version=r},po=function(){this.getEncodingResult=function(o,r){var e=K(o),t=W(e),d=$(t,r),a=q(e,d);return new ho(a,d)}},fo=function(){this.mode=y[this.encodingMode]};fo.fn=fo.prototype={encodingMode:w,utfBOM:"111011111011101110111111",initialModeCountStringLength:20,getEncodingResult:function(o,r){var e=this,t=e.encode(o),d=e.getDataCodewordsCount(t),a=$(d,r),s=e.mode.getModeCountString(t.length/8,a)+t;return new ho(s,a)},getDataCodewordsCount:function(o){var r=o.length;return Math.ceil((this.initialModeCountStringLength+r)/8)},encode:function(o){for(var r=this.utfBOM,e=0;e<o.length;e++)r+=this.encodeCharacter(o.charCodeAt(e));return r},encodeCharacter:function(o){var r=this.getBytesCount(o),e=r-1,t="";if(1==r)t=H(o,8);else{for(var d=8-r,a=0;a<e;a++)t=H(o>>6*a&63|128,8)+t;t=(o>>6*e|255>>d<<d).toString(2)+t}return t},getBytesCount:function(o){for(var r=this.ranges,e=0;e<r.length;e++)if(o<r[e])return e+1},ranges:[128,2048,65536,2097152,67108864]};var Bo=function(o){return o&&o.toLowerCase().indexOf("utf_8")>=0?new fo:new po},Do=function(o,r,e){var t=new Bo(e).getEncodingResult(o,r),d=t.version,a=p[d-1][r],s=b(t.dataString,a.totalDataCodewords),n=G(s,a),l=ro(d);lo(l),uo(l,d),io(l),d>=7&&ao(l,H(0,18)),eo(l,H(0,15)),V(l,n);var u=wo(l),i=l[u];d>=7&&ao([i],to(d));var w=D[r]+H(u,3);return eo([i],X(w)),i},ko={DEFAULT_SIZE:200,QUIET_ZONE_LENGTH:4,DEFAULT_ERROR_CORRECTION_LEVEL:"L",DEFAULT_BACKGROUND:"#fff",DEFAULT_DARK_MODULE_COLOR:"#000",MIN_BASE_UNIT_SIZE:1},Po=s.extend({init:function(r,e){var t=this;s.fn.init.call(t,r,e),t.element=o(r),t.wrapper=t.element,t.element.addClass("k-qrcode"),t.surfaceWrap=o("<div />").css("position","relative").appendTo(this.element),t.surface=d.Surface.create(t.surfaceWrap,{type:t.options.renderAs}),t.setOptions(e)},redraw:function(){var o=this._getSize();this.surfaceWrap.css({width:o,height:o}),this.surface.clear(),this.surface.resize(),this.createVisual(),this.surface.draw(this.visual)},getSize:function(){return e.dimensions(this.element)},_resize:function(){this.redraw()},createVisual:function(){this.visual=this._render()},exportVisual:function(){return this._render()},_render:function(){var o,r,e,t,a,s=this,n=s._value,l=s.options.border||{},u=s.options.padding||0,i=l.width||0;l.width=i;var w=new d.Group;return n&&(e=Do(n,s.options.errorCorrection,s.options.encoding),a=(t=s._getSize())-2*(i+u),o=s._calculateBaseUnit(a,e.length),r=i+u+(a-e.length*o)/2,w.append(s._renderBackground(t,l)),w.append(s._renderMatrix(e,o,r)),s._hasCustomLogo()?w.append(s._renderLogo(t,o)):s._isSwiss()&&w.append(s._renderSwissCode(t,o))),w},_renderLogo:function(o,r){var t,a=_(o/2),s=this._getLogoSize(7*r),n=this.options.overlay.imageUrl,l={x:a-s.width/2,y:a-s.height/2};return t=new e.geometry.Rect(new e.geometry.Point(l.x,l.y),new e.geometry.Size(s.width,s.height)),new d.Image(n,t)},_renderSwissCode:function(o,r){var e=this._getLogoSize(7*r),t=(e=Math.max(e.width,e.height))/4,a=t/2,s=o/2,n={},l=new d.Group;return n.x=n.y=Math.ceil(s-r-e/2),l.append(this._renderShape(n,Math.ceil(e+2*r),Q,"#fff")),n.x=n.y=s-e/2,l.append(this._renderShape(n,e,Q,this.options.color)),n.x=s+a-e/2,n.y=s+a+t-e/2,l.append(this._renderShape(n,t,S,"#fff")),l},_renderShape:function(o,r,e,t){var a=new d.MultiPath({fill:{color:t},stroke:null});a.moveTo(o.x,o.y);for(var s=0;s<e.length;s++)a.lineTo(o.x+r*e[s][0],o.y+r*e[s][1]);return a.close(),a},_getSize:function(){var o,r=this;if(r.options.size)o=parseInt(r.options.size,10);else{var e=r.element,t=Math.min(e.width(),e.height());o=t>0?t:ko.DEFAULT_SIZE}return o},_calculateBaseUnit:function(o,r){var e=Math.floor(o/r);if(e<ko.MIN_BASE_UNIT_SIZE)throw new Error("Insufficient size.");return e*r>=o&&e-1>=ko.MIN_BASE_UNIT_SIZE&&e--,e},_renderMatrix:function(o,r,e){for(var t=new d.MultiPath({fill:{color:this.options.color},stroke:null}),a=0;a<o.length;a++)for(var s=e+a*r,n=0;n<o.length;){for(;0===o[a][n]&&n<o.length;)n++;if(n<o.length){for(var l=n;1==o[a][n];)n++;var u=_(e+l*r),i=_(s),w=_(e+n*r),C=_(s+r);t.moveTo(u,i).lineTo(u,C).lineTo(w,C).lineTo(w,i).close()}}return t},_renderBackground:function(o,r){var e=new n(0,0,o,o).unpad(r.width/2);return d.Path.fromRect(e.toRect(),{fill:{color:this.options.background},stroke:{color:r.color,width:r.width}})},setOptions:function(o){var e=this;o=o||{},e.options=t(e.options,o),o.value!==r&&(e._value=e.options.value+""),e.redraw()},value:function(o){var e=this;if(o===r)return e._value;e._value=o+"",e.redraw()},options:{name:"QRCode",renderAs:"svg",encoding:"ISO_8859_1",value:"",errorCorrection:ko.DEFAULT_ERROR_CORRECTION_LEVEL,background:ko.DEFAULT_BACKGROUND,color:ko.DEFAULT_DARK_MODULE_COLOR,size:"",padding:0,border:{color:"",width:0},overlay:{type:"image",imageUrl:"",width:0,height:0}},_hasCustomLogo:function(){return!!this.options.overlay.imageUrl},_isSwiss:function(){return"swiss"===this.options.overlay.type},_getLogoSize:function(o){var r=this.options.overlay.width,e=this.options.overlay.height;return r||e?r&&!e?e=r:!r&&e&&(r=e):r=e=o,{width:r,height:e}}});a.ExportMixin.extend(Po.fn),a.ui.plugin(Po),e.deepExtend(a,{QRCode:Po,QRCodeDefaults:ko,QRCodeFunctions:{FreeCellVisitor:T,fillData:V,padDataString:b,generateErrorCodewords:Z,xorPolynomials:z,getBlocks:G,multiplyPolynomials:N,chooseMode:j,getModes:K,getDataCodewordsCount:W,getVersion:$,getDataString:q,encodeFormatInformation:X,encodeBCH:J,dividePolynomials:Y,initMatrices:ro,addFormatInformation:eo,encodeVersionInformation:to,addVersionInformation:ao,addCentricPattern:so,addFinderSeparator:no,addFinderPatterns:lo,addAlignmentPatterns:uo,addTimingFunctions:io,scoreMaskMatrixes:wo,encodeData:Do,UTF8Encoder:fo},QRCodeFields:{modes:y,powersOfTwo:C,powersOfTwoResult:g,generatorPolynomials:c}})}(window.kendo.jQuery);
//# sourceMappingURL=kendo.dataviz.qrcode.js.map
