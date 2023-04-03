/**
 * Kendo UI v2023.1.314 (http://www.telerik.com/kendo-ui)
 * Copyright 2023 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";import"./kendo.toolbar.js";var __meta__={id:"scheduler.view",name:"Scheduler View",category:"web",description:"The Scheduler Common View",depends:["core","toolbar"],hidden:!0};kendo.ui.scheduler={},function(t){var e=window.kendo,n=e.ui,i=e.date.getDate,o=n.Widget,s=e._outerHeight,r=e.keys,l=Math,a=" ";function h(t,e){var n=[];return function t(i,o){if(o=o[e])for(var s=n[i]=n[i]||[],r=0;r<o.length;r++)s.push(o[r]),t(i+1,o[r])}(0,t),n}function u(t,n){return t.length?'<table role="presentation" class="'+e.trim("k-scheduler-table "+(n||""))+'"><tr>'+t.join("</tr><tr>")+"</tr></table>":""}var c,d=e.Class.extend({init:function(t,e,n){this._index=t,this._timeSlotCollections=[],this._daySlotCollections=[],this._isRtl=e,this._enforceAllDaySlot=n},addTimeSlotCollection:function(t,e){return this._addCollection(t,e,this._timeSlotCollections)},addDaySlotCollection:function(t,e){return this._addCollection(t,e,this._daySlotCollections)},_addCollection:function(t,e,n){var i=new p(t,e,this._index,n.length);return n.push(i),i},timeSlotCollectionCount:function(){return this._timeSlotCollections.length},daySlotCollectionCount:function(){return this._daySlotCollections.length},daySlotByPosition:function(t,e,n){return this._slotByPosition(t,e,this._daySlotCollections,n)},timeSlotByPosition:function(t,e,n){return this._slotByPosition(t,e,this._timeSlotCollections,n)},_slotByPosition:function(t,e,n,i){for(var o=0;o<n.length;o++)for(var s=n[o],r=0;r<s.count();r++){var l,a=s.at(r),h=a.offsetWidth,u=a.offsetHeight,c=a.offsetLeft+h,d=a.offsetTop+u;if(i||(l=s.at(r+1)),l&&(l.offsetLeft!=a.offsetLeft?c=this._isRtl?a.offsetLeft+(a.offsetLeft-l.offsetLeft):l.offsetLeft:d=l.offsetTop),t>=a.offsetLeft&&t<c&&e>=a.offsetTop&&e<d)return a}},refresh:function(){var t;for(t=0;t<this._daySlotCollections.length;t++)this._daySlotCollections[t].refresh();for(t=0;t<this._timeSlotCollections.length;t++)this._timeSlotCollections[t].refresh()},timeSlotRanges:function(t,n){var i,o,s=this._timeSlotCollections,r=this._startSlot(t,s);!r.inRange&&t>=r.slot.end&&(i=r.slot.collectionIndex+1,r=null);var l=r;if(t<n&&(l=this._endSlot(n,s)),l&&!l.inRange&&n<=l.slot.start&&(o=l.slot.collectionIndex,n===l.slot.start&&(r&&o>r.slot.collectionIndex||o>i)&&(o-=1),l=null),null===r&&null===l){if(n-t<e.date.MS_PER_DAY)return[];r={inRange:!0,slot:s[i].first()},l={inRange:!0,slot:s[o].last()}}if(null===r){if(l.slot.end<=t)return[];r={inRange:!0,slot:(s[i]||s[l.slot.collectionIndex]).first()}}if(null===l){if(r.slot.start>=n)return[];l={inRange:!0,slot:(s[o]||s[r.slot.collectionIndex]).last()}}return this._continuousRange(g,s,r,l)},daySlotRanges:function(t,n,i){var o=this._daySlotCollections,s=this._startSlot(t,o,i);!s.inRange&&t>=s.slot.end&&(s=null);var r=s;if(t<n&&(r=this._endSlot(n,o,i)),r&&!r.inRange&&n<=r.slot.start&&(r=null),null===s&&null===r)return[];if(null===s){if(r.slot.end<=t)return[];do{t+=e.date.MS_PER_DAY,s=this._startSlot(t,o,i)}while(!s.inRange&&t>=s.slot.end)}if(null===r){if(s.slot.start>=n)return[];do{n-=e.date.MS_PER_DAY,r=this._endSlot(n,o,i)}while(!r.inRange&&n<=r.slot.start)}return this._continuousRange(v,o,s,r)},_continuousRange:function(t,e,n,i){for(var o=n.slot,s=i.slot,r=o.collectionIndex,l=s.collectionIndex,a=[],h=r;h<=l;h++){var u=e[h],c=u.first(),d=u.last(),f=!1,g=!1;h==r&&(g=!n.inRange),h==l&&(f=!i.inRange),c.start<o.start&&(c=o),d.start>s.start&&(d=s),r<l&&(h==r?f=!0:h==l?g=!0:f=g=!0),a.push(new t({start:c,end:d,collection:u,head:f,tail:g}))}return a},slotRanges:function(t,n){var i=t._startTime||e.date.toUtcTime(t.start),o=t._endTime||e.date.toUtcTime(t.end);return void 0===n&&(n=this._enforceAllDaySlot?t.isMultiDay():t.isAllDay),n?this.daySlotRanges(i,o,t.isAllDay):this.timeSlotRanges(i,o)},ranges:function(t,n,i,o){return"number"!=typeof t&&(t=e.date.toUtcTime(t)),"number"!=typeof n&&(n=e.date.toUtcTime(n)),i?this.daySlotRanges(t,n,o):this.timeSlotRanges(t,n)},_startCollection:function(t,e){for(var n=0;n<e.length;n++){var i=e[n];if(i.startInRange(t))return i}return null},_endCollection:function(t,e,n){for(var i=0;i<e.length;i++){var o=e[i];if(o.endInRange(t,n))return o}return null},_getCollections:function(t){return t?this._daySlotCollections:this._timeSlotCollections},continuousSlot:function(t,e){var n=e?-1:1,i=this._getCollections(t.isDaySlot)[t.collectionIndex+n];return i?i[e?"last":"first"]():void 0},firstSlot:function(){return this._getCollections(this.daySlotCollectionCount())[0].first()},lastSlot:function(){var t=this._getCollections(this.daySlotCollectionCount());return t[t.length-1].last()},upSlot:function(t,e,n){var i=this;return this.timeSlotCollectionCount()||(e=!0),this._verticalSlot(t,-1,(function(t,n,o){if(!e&&!t&&0===o&&i.daySlotCollectionCount())return i._daySlotCollections[0].at(n)}),n)},downSlot:function(t,e,n){var i=this;return this.timeSlotCollectionCount()||(e=!0),this._verticalSlot(t,1,(function(t,n,o){if(!e&&t&&i.timeSlotCollectionCount())return i._timeSlotCollections[o].at(0)}),n)},leftSlot:function(t,e){return this._horizontalSlot(t,-1,e)},rightSlot:function(t,e){return this._horizontalSlot(t,1,e)},_horizontalSlot:function(t,e,n){var i=t.index,o=t.isDaySlot,s=t.collectionIndex,r=this._getCollections(o);(o=!n&&o)?i+=e:s+=e;var l=r[s];return l?l.at(i):void 0},_verticalSlot:function(t,e,n,i){var o=t.index,s=t.isDaySlot,r=t.collectionIndex,l=this._getCollections(s);if(t=n(s,r,o))return t;(s=!i&&s)?r+=e:o+=e;var a=l[r];return a?a.at(o):void 0},_collection:function(t,e){return(e?this._daySlotCollections:this._timeSlotCollections)[t]},_startSlot:function(t,e,n){var i=this._startCollection(t,e),o=!0,s=0;if(!i){for(i=e[s];s<e.length-1&&i._start<t;)i=e[++s];o=!1}var r=i.slotByStartDate(t,n);return r||(r=i.first(),o=!1),{slot:r,inRange:o}},_endSlot:function(t,e,n){var i=this._endCollection(t,e,n),o=!0,s=e.length-1;if(!i){for(i=e[s];s>0&&i._start>t;)i=e[--s];o=!1}var r=i.slotByEndDate(t,n);return r||(r=t<=i.first().start?i.first():i.last(),o=!1),{slot:r,inRange:o}},getSlotCollection:function(t,e){return this[e?"getDaySlotCollection":"getTimeSlotCollection"](t)},getTimeSlotCollection:function(t){return this._timeSlotCollections[t]},getDaySlotCollection:function(t){return this._daySlotCollections[t]}}),f=e.Class.extend({init:function(e){t.extend(this,e)},innerHeight:function(){for(var t=this.collection,e=this.start.index,n=this.end.index,i=0,o=e;o<=n;o++)i+=t.at(o).offsetHeight;return i},events:function(){return this.collection.events()},addEvent:function(t){this.events().push(t)},startSlot:function(){return this.start.offsetLeft>this.end.offsetLeft?this.end:this.start},endSlot:function(){return this.start.offsetLeft>this.end.offsetLeft?this.start:this.end}}),g=f.extend({innerHeight:function(){for(var t=this.collection,e=this.start.index,n=this.end.index,i=0,o=e;o<=n;o++)i+=t.at(o).offsetHeight;return i},outerRect:function(t,e,n){return this._rect("offset",t,e,n)},_rect:function(t,n,i,o){var s,r,l,a,h=this.start,u=this.end,c=e.support.isRtl(h.element);if("number"!=typeof n&&(n=e.date.toUtcTime(n)),"number"!=typeof i&&(i=e.date.toUtcTime(i)),o)s=h.offsetTop,r=u.offsetTop+u[t+"Height"],c?(l=u.offsetLeft,a=h.offsetLeft+h[t+"Width"]):(l=h.offsetLeft,a=u.offsetLeft+u[t+"Width"]);else{var d=n-h.start;d<0&&(d=0);var f=h.end-h.start;s=h.offsetTop+h[t+"Height"]*d/f;var g=u.end-i;g<0&&(g=0);var v=u.end-u.start;r=u.offsetTop+u[t+"Height"]-u[t+"Height"]*g/v,c?(l=Math.round(u.offsetLeft+u[t+"Width"]*g/v),a=Math.round(h.offsetLeft+h[t+"Width"]-h[t+"Width"]*d/f)):(l=Math.round(h.offsetLeft+h[t+"Width"]*d/f),a=Math.round(u.offsetLeft+u[t+"Width"]-u[t+"Width"]*g/v))}return{top:s,bottom:r,left:0===l?l:l+1,right:a}},innerRect:function(t,e,n){return this._rect("client",t,e,n)}}),v=f.extend({innerWidth:function(){for(var t=this.collection,e=this.start.index,n=this.end.index,i=0,o=e!==n?"offsetWidth":"clientWidth",s=e;s<=n;s++)i+=t.at(s)[o];return i}}),p=e.Class.extend({init:function(t,n,i,o){this._slots=[],this._events=[],this._start=e.date.toUtcTime(t),this._end=e.date.toUtcTime(n),this._groupIndex=i,this._collectionIndex=o},refresh:function(){for(var t=0;t<this._slots.length;t++)this._slots[t].refresh()},startInRange:function(t){return this._start<=t&&t<this._end},endInRange:function(t,e){var n=e?t<this._end:t<=this._end;return this._start<=t&&n},slotByStartDate:function(t){var n=t;"number"!=typeof n&&(n=e.date.toUtcTime(t));for(var i=0;i<this._slots.length;i++){var o=this._slots[i];if(o.startInRange(n))return o}return null},slotByEndDate:function(t,n){var i=t;if("number"!=typeof i&&(i=e.date.toUtcTime(t)),n)return this.slotByStartDate(t,!1);for(var o=0;o<this._slots.length;o++){var s=this._slots[o];if(s.endInRange(i))return s}return null},count:function(){return this._slots.length},events:function(){return this._events},addTimeSlot:function(t,e,n,i){var o=new m(t,e,n,this._groupIndex,this._collectionIndex,this._slots.length,i);this._slots.push(o)},addDaySlot:function(t,e,n,i){var o=new S(t,e,n,this._groupIndex,this._collectionIndex,this._slots.length,i);this._slots.push(o)},first:function(){return this._slots[0]},last:function(){return this._slots[this._slots.length-1]},at:function(t){return this._slots[t]}}),_=e.Class.extend({init:function(t,e,n,i,o,s){this.element=t,this.clientWidth=t.clientWidth,this.clientHeight=t.clientHeight,this.offsetWidth=t.offsetWidth,this.offsetHeight=t.offsetHeight,this.offsetTop=t.offsetTop,this.offsetLeft=t.offsetLeft,this.start=e,this.end=n,this.element=t,this.groupIndex=i,this.collectionIndex=o,this.index=s,this.isDaySlot=!1},refresh:function(){var t=this.element;this.clientWidth=t.clientWidth,this.clientHeight=t.clientHeight,this.offsetWidth=t.offsetWidth,this.offsetHeight=t.offsetHeight,this.offsetTop=t.offsetTop,this.offsetLeft=t.offsetLeft},startDate:function(){return e.timezone.toLocalDate(this.start)},endDate:function(){return e.timezone.toLocalDate(this.end)},startInRange:function(t){return this.start<=t&&t<this.end},endInRange:function(t){return this.start<t&&t<=this.end},startOffset:function(){return this.start},endOffset:function(){return this.end}}),m=_.extend({init:function(t,e,n,i,o,s,r){_.fn.init.apply(this,arguments),this.isHorizontal=!!r},offsetX:function(t,e){return this.offsetLeft+e},startInRange:function(t){return this.start<=t&&t<this.end},endInRange:function(t){return this.start<t&&t<=this.end},startOffset:function(n,i,o){if(o)return this.start;var s,r,l=t(this.element).offset(),a=this.end-this.start;if(this.isHorizontal){var h=e.support.isRtl(this.element);if(s=n-l.left,r=Math.floor(a*(s/this.offsetWidth)),h)return this.start+a-r}else s=i-l.top,r=Math.floor(a*(s/this.offsetHeight));return this.start+r},endOffset:function(n,i,o){if(o)return this.end;var s,r,l=t(this.element).offset(),a=this.end-this.start;if(this.isHorizontal){var h=e.support.isRtl(this.element);if(s=n-l.left,r=Math.floor(a*(s/this.offsetWidth)),h)return this.start+a-r}else s=i-l.top,r=Math.floor(a*(s/this.offsetHeight));return this.start+r}}),S=_.extend({init:function(t,e,n,i,o,s,r){if(_.fn.init.apply(this,arguments),this.eventCount=r,this.isDaySlot=!0,this.element.children.length){var l=this.element.children[0];this.firstChildHeight=l.offsetHeight,this.firstChildTop=l.offsetTop}else this.firstChildHeight=3,this.firstChildTop=0},startDate:function(){var t=new Date(this.start);return e.timezone.apply(t,"Etc/UTC")},endDate:function(){var t=new Date(this.end);return e.timezone.apply(t,"Etc/UTC")},startInRange:function(t){return this.start<=t&&t<this.end},endInRange:function(t){return this.start<t&&t<=this.end}});function y(t){return{start:t.start,end:t.end}}e.ui.SchedulerView=o.extend({init:function(n,i){o.fn.init.call(this,n,t.extend({},this.options,i)),this._normalizeOptions(),this._initDefaultTools(),this._scrollbar=c=c||e.support.scrollbar(),this._isRtl=e.support.isRtl(n),this._resizeHint=t(),this._moveHint=t(),this._cellId=e.guid(),this._resourcesForGroups(),this._selectedSlots=[],this.element.attr("role","application")},options:{messages:{ariaEventLabel:{on:"on",at:"at",to:"to",allDay:"(all day)",prefix:""}}},visibleEndDate:function(){return this.endDate()},_initDefaultTools:function(){this._defaultTools={todayMobile:{type:"button",fillMode:"flat",text:this.options.messages.today,click:this._footerTodayClickHandler.bind(this),attributes:{class:"k-scheduler-today"}},fulldayDesktop:{type:"button",icon:"clock",text:this.options.showWorkHours?this.options.messages.showFullDay:this.options.messages.showWorkDay,click:this.toggleFullDay?this.toggleFullDay.bind(this):t.noop,attributes:{class:"k-scheduler-fullday"}},fulldayMobile:{type:"button",fillMode:"flat",text:this.options.showWorkHours?this.options.messages.showFullDay:this.options.messages.showWorkDay,click:this.toggleFullDay?this.toggleFullDay.bind(this):t.noop,attributes:{class:"k-scheduler-fullday"}}}},_normalizeOptions:function(){var t=this.options;t.startTime&&t.startTime.setMilliseconds(0),t.endTime&&t.endTime.setMilliseconds(0),t.workDayStart&&t.workDayStart.setMilliseconds(0),t.workDayEnd&&t.workDayEnd.setMilliseconds(0)},_isMobile:function(){var t=this.options;return!0===t.mobile&&e.support.mobileOS||"phone"===t.mobile||"tablet"===t.mobile},_addResourceView:function(){var t=new d(this.groups.length,this._isRtl,this.options.enforceAllDaySlot);return this.groups.push(t),t},dateForTitle:function(){return e.format(this.options.selectedDateFormat,this.startDate(),this.endDate())},shortDateForTitle:function(){return e.format(this.options.selectedShortDateFormat,this.startDate(),this.endDate())},mobileDateForTitle:function(){return e.format(this.options.selectedMobileDateFormat||this.options.selectedShortDateFormat,this.startDate(),this.endDate())},_changeGroup:function(t,e){var n=this[e?"prevGroupSlot":"nextGroupSlot"](t.start,t.groupIndex,t.isAllDay);return n&&(t.groupIndex+=e?-1:1),this._isGroupedByDate()&&!n&&(t.groupIndex=e?this.groups.length-1:0),n},_changeDate:function(t,e,n){var i,o,s=this.groups[t.groupIndex];if(n){if(i=s._getCollections(!1),(o=s.daySlotCollectionCount()?e.index-1:e.collectionIndex-1)>=0)return i[o]._slots[i[o]._slots.length-1]}else{i=s._getCollections(s.daySlotCollectionCount()),o=s.daySlotCollectionCount()?0:e.collectionIndex+1;var r=s.daySlotCollectionCount()?e.collectionIndex+1:0;if(i[o]&&i[o]._slots[r])return i[o]._slots[r]}},_changeGroupContinuously:function(){return null},_changeViewPeriod:function(){return!1},_isInRange:function(t,e){return!!(t&&e&&this.options.min&&this.options.max)&&(i(t)<=i(this.options.min)||i(e)>=i(this.options.max))},_horizontalSlots:function(t,e,n,i){var o,s=i?"leftSlot":"rightSlot",r={startSlot:e[0].start,endSlot:e[e.length-1].end},l=this.groups[t.groupIndex],a=this._isVerticallyGrouped();if(!n){var h=this._normalizeHorizontalSelection(t,e,i);h&&(r.startSlot=r.endSlot=h)}if(this._isGroupedByDate()&&!n){var u=this._changeGroup(t,i);u?r.startSlot=r.endSlot=u:r=this._getNextHorizontalRange(l,s,r)}else r.startSlot=l[s](r.startSlot),r.endSlot=l[s](r.endSlot),n||a||r.startSlot&&r.endSlot||(r.startSlot=r.endSlot=this._changeGroup(t,i));return r.startSlot&&r.endSlot||this._isGroupedByDate()||(o=this._continuousSlot(t,e,i),(o=this._changeGroupContinuously(t,o,n,i))&&(r.startSlot=r.endSlot=o)),r},_getNextHorizontalRange:function(t,e,n){return this._isVerticallyGrouped()||(n.startSlot=t[e](n.startSlot),n.endSlot=t[e](n.endSlot)),n},_verticalSlots:function(t,e,n,i){var o,s=this.groups[t.groupIndex],r={startSlot:e[0].start,endSlot:e[e.length-1].end};n||(o=this._normalizeVerticalSelection(t,e,i))&&(r.startSlot=r.endSlot=o);var l=i?"upSlot":"downSlot";return r=this._getNextVerticalRange(s,l,r,n),n||!this._isVerticallyGrouped()||r.startSlot&&r.endSlot||(this._isGroupedByDate()?r.startSlot=r.endSlot=this._changeDate(t,o,i):r.startSlot=r.endSlot=this._changeGroup(t,i)),r},_getNextVerticalRange:function(t,e,n,i){return n.startSlot=t[e](n.startSlot,i),n.endSlot=t[e](n.endSlot,i),n},_normalizeHorizontalSelection:function(){return null},_normalizeVerticalSelection:function(t,e,n){return n?e[0].start:e[e.length-1].end},_continuousSlot:function(){return null},_footerTodayClickHandler:function(t){t.preventDefault();var n,i=this,o=i.options,s=i.options.timezone,r=new Date;if(s){var l=e.timezone.offset(r,s);n=e.timezone.convert(r,r.getTimezoneOffset(),l)}else n=r;i.trigger("navigate",{view:i.name||o.name,action:"today",date:n})},_footerItems:function(){var t=this,e=[],n=this.options;return t._isMobile()&&e.push({type:"button",fillMode:"flat",text:n.messages.today,click:t._footerTodayClickHandler.bind(t),attributes:{class:"k-scheduler-today"}}),e},_footer:function(){if(!1!==this.options.footer){var e=this,n=e._footerItems();if(n.length>0){var i=t('<div class="k-scheduler-footer">');e.footer=i.appendTo(e.element),e.footer.kendoToolBar({resizable:!1,items:n})}}},constrainSelection:function(t){var e,n=this.groups[0];this.inRange(t)?n.daySlotCollectionCount()?n.timeSlotCollectionCount()||(t.isAllDay=!0):t.isAllDay=!1:(e=n.firstSlot(),t.isAllDay=e.isDaySlot,t.start=e.startDate(),t.end=e.endDate()),this.groups[t.groupIndex]||(t.groupIndex=0)},move:function(t,e,n){var i=!1,o=this.groups[t.groupIndex],s=this._isGroupedByDate()&&this._isVerticallyGrouped();o.timeSlotCollectionCount()||(t.isAllDay=!0);var l,a,h,u,c=o.ranges(t.start,t.end,t.isAllDay,!1);if(e===r.DOWN||e===r.UP){if(i=!0,h=e===r.UP,this._updateDirection(t,c,n,h,!0),!(u=this._verticalSlots(t,c,n,h)).startSlot&&!n&&this._changeViewPeriod(t,h,!s))return i}else if((e===r.LEFT||e===r.RIGHT)&&(i=!0,h=e===r.LEFT,this._updateDirection(t,c,n,h,!1),!(u=this._horizontalSlots(t,c,n,h)).startSlot&&!n&&this._changeViewPeriod(t,h,s)))return i;if(i){if(l=u.startSlot,a=u.endSlot,n){var d=t.backward;d&&l?t.start=l.startDate():!d&&a&&(t.end=a.endDate())}else l&&a&&(t.isAllDay=l.isDaySlot,t.start=l.startDate(),t.end=a.endDate());t.events=[]}return i},moveToEventInGroup:function(e,n,i,o){var s,r,l,a=e._continuousEvents||[],h=o?-1:1,u=a.length,c=o?u-1:0;if(i.length)if(l=i[i.length-1],o)for(r=0;r<a.length;r++)a[r].uid===l&&(c=r+h);else for(r=a.length-1;r>-1;r--)a[r].uid===l&&(c=r+h);for(;c<u&&c>-1;){if(s=a[c],(!o&&s.start.startDate()>=n.startDate()||o&&s.start.startDate()<=n.startDate())&&s&&-1===t.inArray(s.uid,i)){!!s;break}c+=h}return s},moveToEvent:function(t,e){var n,i=t.groupIndex,o=this.groups[i],s=o.ranges(t.start,t.end,"month"===this.name||t.isAllDay,!1)[0].start,r=this.groups.length,l=e?-1:1,a=t.events;if(this._isGroupedByDate()){var h=this._getAllEvents(),u=this._getUniqueEvents(h),c=this._getSortedEvents(u);if(0===a.length){var d=this._getNextEventIndexBySlot(s,c,i);e&&d--,n=c[d]}else for(var f=this._getStartIdx(a,c);f<c.length&&f>-1&&(a.length>0&&(s=this._getSelectedSlot(s,c,n,f,l,e)),s);){if((!e&&c[f].start.startDate()>=s.startDate()||e&&c[f].start.startDate()<=s.startDate())&&a[0]!=c[f].uid){n=c[f];break}f+=l}}else for(;i<r&&i>-1&&(n=this.moveToEventInGroup(o,s,a,e),i+=l,(o=this.groups[i])&&!n);)a=[],s=e?o.lastSlot():o.firstSlot(!0);return n&&(t.events=[n.uid],t.start=n.start.startDate(),t.end=n.end.endDate(),t.isAllDay=n.start.isDaySlot,t.groupIndex=n.start.groupIndex,t.eventElement=n.element[0]),!!n},current:function(t){if(void 0===t)return this._current;this._current=t,this.content.has(t)&&this._scrollTo(t,this.content[0])},select:function(t){this.clearSelection(),this._selectEvents(t)||this._selectSlots(t)},_getNextEventIndexBySlot:function(t,n,i){for(var o=0,s=e.date.getDate(t.startDate()),r=0;r<n.length;r++){var l=e.date.getDate(n[r].start.startDate());if(s>l)o++;else if(s.getTime()===l.getTime()&&i>n[r].start.groupIndex)o++;else{if(!(s.getTime()===l.getTime()&&i>=n[r].start.groupIndex&&t.startDate()>n[r].start.startDate()))break;o++}}return o},_getSelectedSlot:function(t,e,n,i,o,s){if(e[i+o]&&e[i].start.groupIndex!==e[i+o].start.groupIndex){var r=e[i+o].start.groupIndex,l=this.groups[r];l&&!n||(t=null),t=s?l.lastSlot():l.firstSlot(!0)}return t},_getStartIdx:function(e,n){var i=0;return t.each(n,(function(){if(this.uid===e[0])return!1;i++})),i},_getAllEvents:function(){for(var t=[],e=this.groups,n=0;n<e.length;n++)e[n]._continuousEvents&&(t=t.concat(e[n]._continuousEvents));return t},_getUniqueEvents:function(t){for(var e=[],n=0;n<t.length;n++){for(var i=!1,o=0;o<e.length;o++)if(t[n].uid===e[o].uid){i=!0;break}i||e.push(t[n])}return e},_getSortedEvents:function(n){return n.sort((function(n,i){var o=n.start.startDate(),s=i.start.startDate(),r=e.date.getDate(o)-e.date.getDate(s);return 0===r&&(r=n.start.groupIndex-i.start.groupIndex),0===r&&(r=o.getTime()-s.getTime()),0===r&&(n.start.isDaySlot&&!i.start.isDaySlot&&(r=-1),!n.start.isDaySlot&&i.start.isDaySlot&&(r=1)),0===r&&(r=t(n.element).index()-t(i.element).index()),r}))},_selectSlots:function(t){var e=t.isAllDay,n=this.groups[t.groupIndex];n.timeSlotCollectionCount()||(e=!0),this._selectedSlots=[];for(var i,o,s,r=n.ranges(t.start,t.end,e,!1),l=0;l<r.length;l++)for(var a=r[l],h=a.collection,u=a.start.index;u<=a.end.index;u++)i=(o=h.at(u)).element,(s=i).className=s.className.replace(w,"")+" k-selected",this._selectedSlots.push({start:o.startDate(),end:o.endDate(),element:i});t.backward&&(i=r[0].start.element),this.current(i)},_selectEvents:function(e){var n,i,o=!1,s=e.events,r=this._getAllEvents(),l=r.length;if(!s[0]||!r[0])return o;var a=t();for(e.events=[],n=0;n<l;n++)t.inArray(r[n].uid,s)>-1&&(i=r[n],a=a.add(i.element),-1===e.events.indexOf(i.uid)&&e.events.push(i.uid));return a[0]&&(a.addClass("k-selected"),e.eventElement?this.current(e.eventElement):this.current(a.last()[0]),this._selectedSlots=[],o=!0),o},inRange:function(t){var n=this.startDate(),i=e.date.addDays(this.endDate(),1),o=t.start,s=t.end;return n<=o&&o<i&&n<s&&s<=i},_resourceValue:function(t,n){return t.valuePrimitive&&(n=e.getter(t.dataValueField)(n)),n},_setResourceValue:function(t,n,i){var o=t.value;n.multiple&&(o=[o]),e.setter(n.field)(i,o)},_resourceBySlot:function(t){var e=this.groupedResources,n={};if(e.length){var i,o,s,r,l=t.groupIndex,a=this.options.group,h=a.date||"horizontal"===a.orientation?"columns":"rows",u="rows"===h?this.rowLevels:this.columnLevels,c=a.date&&"horizontal"===a.orientation?1:0,d=u[e.length-1+c],f=e[e.length-1],g=d[l];for(this._setResourceValue(g,f,n),s=e.length-2;s>=0;s--)for(d=u[s+c],f=e[s],i=0,r=0;r<d.length;r++)(o=(g=d[r])[h].length)>l-i?(this._setResourceValue(g,f,n),r=d.length):i+=o}return n},_createResizeHint:function(e,n,i,o){return t('<div class="k-marquee k-scheduler-marquee"><div class="k-marquee-color"></div><div class="k-marquee-text"><div class="k-label-top"></div><div class="k-label-bottom"></div></div></div>').css({left:e,top:n,width:i,height:o})},_removeResizeHint:function(){this._resizeHint.remove(),this._resizeHint=t()},_removeMoveHint:function(e){e?(this._moveHint.filter("[data-uid='"+e+"']").remove(),this._moveHint=this._moveHint.filter("[data-uid!='"+e+"']")):(this._moveHint.remove(),this._moveHint=t())},_scrollTo:function(t,e){var n=t.offsetTop,i=t.offsetHeight,o=e.scrollTop,s=e.clientHeight,r=n+i,l=0;l=o>n?n:r>o+s?i<=s?r-s:n:o,e.scrollTop=l},_inverseEventColor:function(t){var e=t.css("color"),n=new b(e).isDark(),i=t.css("background-color");n==new b(i).isDark()&&t.addClass("k-event-inverse")},_eventTmpl:function(n,i){var o=this.options,s=t.extend({},e.Template,o.templateSettings),r=s.paramName,l="",a=typeof n,h={storage:{},count:0};"function"===a?(h.storage["tmpl"+h.count]=n,l+="#=this.tmpl"+h.count+"("+r+")#",h.count++):"string"===a&&(l+=n);var u=e.template(e.format(i,l),s);return h.count>0&&(u=u.bind(h.storage)),u},eventResources:function(t){var n=[],i=this.options;if(!i.resources)return n;for(var o=0;o<i.resources.length;o++){var s=i.resources[o],r=s.field,l=e.getter(r)(t);if(null!=l){s.multiple||(l=[l]);for(var a=s.dataSource.view(),h=0;h<l.length;h++){var u=null,c=l[h];s.valuePrimitive||(c=e.getter(s.dataValueField)(c));for(var d=0;d<a.length;d++)if(a[d].get(s.dataValueField)==c){u=a[d];break}if(null!==u){var f=e.getter(s.dataColorField)(u);n.push({field:s.field,title:s.title,name:s.name,text:e.getter(s.dataTextField)(u),value:c,color:f})}}}}return n},createLayout:function(n){var i=-1;n.rows||(n.rows=[]);for(var o=0;o<n.rows.length;o++)if(n.rows[o].allDay){i=o;break}var s=n.rows[i];i>=0&&n.rows.splice(i,1);var r=this.columnLevels=h(n,"columns"),l=this.rowLevels=h(n,"rows");this._isVirtualized()&&this._trimRowLevels(l),this.table=t('<table role="presentation" class="k-scheduler-layout k-scheduler-'+this.name+'view"><tbody></tbody></table>');var a=l[l.length-1].length;this.table.find("tbody").first().append(this._topSection(r,s,a)),this.table.find("tbody").first().append(this._bottomSection(r,l,a)),this.element.append(this.table),this._isVirtualized()&&this._updateDomRowLevels(),this._isMobile()&&r.length>1&&"horizontal"===this._groupOrientation()&&e._outerWidth(t(window))<1024&&(this.table.find(".k-scheduler-content .k-scheduler-table").width(100*r[r.length-2].length+"%"),this.table.find(".k-scheduler-header .k-scheduler-table").width(100*r[r.length-2].length+"%")),this._scroller()},_isVirtualized:function(){return this.options.virtual&&this.rowLevels.length>1&&this._isVerticallyGrouped()},_trimRowLevels:function(t){var e,n=t[t.length-2],i=this.cachedRowLevels||[];this._hasContentToRender=!0;for(var o=function(t,e){var n,i;return!(t[e-1].length>0)||(n=t[e-1][0],i=t[e][0].parentValue,n.value!==i)},s=t.length-2;s>=0;s--){var r=!1;if(s>0&&o(t,s)&&(r=!0,e=s),i[s]=t[s].splice(1),s<t.length-2&&1!=t[s][0].rows.length&&(t[s][0].rows=t[s+1]),r)break}return i[t.length-1]=t[t.length-1].splice(n[0].rows.length),this.cachedRowLevels=i,i[i.length-1].length||(this._hasContentToRender=!1),{levelMarker:e||0,rowLevels:t}},createNextLayout:function(){for(var t,e,n,i,o=[],s=0;s<this.cachedRowLevels.length;s++)o[s]=this.cachedRowLevels[s];e=(t=this._trimRowLevels(o)).rowLevels.splice(t.levelMarker),n=t.levelMarker,i=e[e.length-1].length,delete this._height;for(var r=n;r<this.rowLevels.length;r++)this.rowLevels[r]=this.rowLevels[r].concat(e[r-n]);if(this.table.find(".k-scheduler-times").last().find("tbody").append(this._times(e,i,this._isMobile()).find("tr")),this._updateDomRowLevels(),n>0)for(r=0;r<n;r++){var l=this.table.find("[data-row-level="+r+"]").last(),a=parseInt(l.attr("rowspan"),10)+i;l.attr("rowspan",a)}this._virtualContent(e,this.columnLevels),this.render(this._cachedEvents)},_tryRenderContent:function(){for(var t=this,e=t.table.innerHeight(),n=t.content.find("table").innerHeight(),i=t.content.scrollTop();t._hasContentToRender&&n-e<i;)t.createNextLayout(),n=t.content.find("table").innerHeight()},_isSchedulerHeightSet:function(){var t,e=this.element;return!!e[0].style.height||(t=e.height(),e.height("auto"),t!=e.height()?(e.height(""),!0):(e.height(""),!1))},_updateDomRowLevels:function(){var e=this.times.find(".k-scheduler-group-cell:not([data-row-level])");if(this._rowLevelIndices){e=e.toArray().reverse();for(var n=0;n<=e.length;n++)t(e[n]).attr("data-row-level",this._rowLevelIndices[n])}else this._rowLevelIndices=e.map((function(e,n){return t(n).attr("data-row-level",e),e})).toArray().reverse()},refreshLayout:function(){for(var n=this,i=n.element.find("> .k-scheduler-toolbar"),o=n.element.innerHeight(),r=this._scrollbar,l=0,a=this._isRtl?"left":"right",h=0;h<i.length;h++)o-=s(i.eq(h));if(n.datesHeader&&(l=s(n.datesHeader)),n.timesHeader&&s(n.timesHeader)>l&&(l=s(n.timesHeader)),n.datesHeader&&n.timesHeader){var u=n.datesHeader.find("table").first().find("tr");n.timesHeader.find("tr").height((function(e){t(this).height(u.eq(e).height())}))}l&&(o-=l),n.footer&&(o-=s(n.footer));var c=n.content[0],d=e.support.kineticScrollNeeded?0:r;if(this._isSchedulerHeightSet()&&(o>2*r?n.content.height(o):n.content.height(2*r+1),n.times)){n.times.height(c.clientHeight);var f=n.times.find("table");f.length&&f.height(n.content.find("table")[0].clientHeight)}n.table&&(c.offsetWidth-c.clientWidth>0?(n.table.addClass("k-scrollbar-v"),n.datesHeader.css("padding-"+a,d-parseInt(n.datesHeader.children().css("border-"+a+"-width"),10))):n.datesHeader.css("padding-"+a,"0"),c.offsetHeight-c.clientHeight>0||c.clientHeight>n.content.children(".k-scheduler-table").height()?n.table.addClass("k-scrollbar-h"):n.table.removeClass("k-scrollbar-h"))},_topSection:function(e,n,i){var o=t("<tr>");this.timesHeader=function(e,n,i){var o=[];if(i>0)for(var s=0;s<e;s++)o.push("<th>&#8203;</th>");return n&&o.push('<th class="k-scheduler-times-all-day">'+n.text+"</th>"),i<1?t():t('<div class="k-scheduler-times">'+u(o)+"</div>")}(e.length,n,i),this.datesHeader=this._datesHeader(e,n);var s=this.datesHeader.find(".k-nav-day");return s.length&&s.closest("tr").addClass("k-scheduler-date-group"),this._isMobile()&&(o.addClass("k-mobile-header"),o.addClass("k-mobile-"+this._groupOrientation()+"-header")),t(o).append(this.timesHeader.add(this.datesHeader).wrap("<td>").parent())},_bottomSection:function(e,n,i){return this.times=this._times(n,i,this._isMobile()),this.content=(e[e.length-1],n[n.length-1],t('<div class="k-scheduler-content"><table role="presentation" class="k-scheduler-table"></table></div>')),t("<tr>").append(this.times.add(this.content).wrap("<td>").parent())},_scroller:function(){var n=this;this.content.on("scroll.kendoSchedulerView",(function(){e.scrollLeft(n.datesHeader.find(">.k-scheduler-header-wrap"),this.scrollLeft),n.times.scrollTop(this.scrollTop),n._isVirtualized()&&n._tryRenderContent()}));var i=e.touchScroller(this.content,{avoidScrolling:function(e){return t(e.event.target).closest(".k-event.k-event-active").length>0}});i&&i.movable&&(this._touchScroller=i,this.content=i.scrollElement,i.movable.bind("change",(function(t){e.scrollLeft(n.datesHeader.find(">.k-scheduler-header-wrap"),-t.sender.x),n.times.scrollTop(-t.sender.y),n._isVirtualized()&&n._tryRenderContent()})))},_resourcesForGroups:function(){var t=[],e=this.options.group,n=this.options.resources;if(e=e&&e.resources?e.resources:[],n&&e.length)for(var i=0,o=n.length;i<o;i++)for(var s=0,r=e.length;s<r;s++)n[i].name===e[s]&&t.push(n[i]);this.groupedResources=t},_createDateLayout:function(t,e,n){return C("rows",t,e,n)},_createColumnsLayout:function(t,e,n,i,o,s){return x("columns",t,e,n,i,o,s)},_groupOrientation:function(){var t=this.options.group;return t&&t.resources?t.orientation:"horizontal"},_isGroupedByDate:function(){return this.options.group&&this.options.group.date},_isVerticallyGrouped:function(){return this.groupedResources.length&&"vertical"===this._groupOrientation()},_createRowsLayout:function(t,e,n,i){return x("rows",t,e,n,i)},selectionByElement:function(){return null},clearSelection:function(){this.content.find(".k-selected").removeAttr("id").removeClass("k-selected")},destroy:function(){var t=this;o.fn.destroy.call(this),t.table&&(e.destroy(t.table),t.table.remove()),t.footer&&(t.footer.getKendoToolBar().destroy(),t.footer.remove()),t.groups=null,t.table=null,t.content=null,t.times=null,t.datesHeader=null,t.timesHeader=null,t.footer=null,t._resizeHint=null,t._moveHint=null},calendarInfo:function(){return e.getCulture().calendars.standard},prevGroupSlot:function(t,e,n){var i,o=this.groups[e],s=o.ranges(t,t,n,!1)[0].start;if(!(e<=0))return this._isGroupedByDate()?s:this._isVerticallyGrouped()?o.timeSlotCollectionCount()?(i=o._collection(n?s.index:s.collectionIndex,!1)).last():(i=o._collection(o.daySlotCollectionCount()-1,!0)).at(s.index):o.timeSlotCollectionCount()?(i=o._collection(n?0:o.timeSlotCollectionCount()-1,n),n?i.last():i.at(s.index)):(i=o._collection(s.collectionIndex,!0)).last()},nextGroupSlot:function(t,e,n){var i,o,s=this.groups[e],r=s.ranges(t,t,n,!1)[0].start;if(!(e>=this.groups.length-1))return this._isGroupedByDate()?r:this._isVerticallyGrouped()?s.timeSlotCollectionCount()?(o=s.daySlotCollectionCount(),i=s._collection(o?0:r.collectionIndex,o),n?i.first():i.at(r.collectionIndex)):(i=s._collection(0,!0)).at(r.index):s.timeSlotCollectionCount()?(i=s._collection(0,n),n?i.first():i.at(r.index)):(i=s._collection(r.collectionIndex,!0)).first()},_eventOptionsForMove:function(){return{}},_updateEventForResize:function(){},_updateEventForSelection:function(t){return t},_innerElements:function(t,e,n){var i=0,o=function(t){var s,r,l,a=t[n],h=t[e];if(a)i+=a;else if(h&&0!==h.length)for(l=0;l<h.length;l++)(r=(s=h[l])[e])&&r[0]?r[0][e]&&0!==r[0][e].length?o(s):i+=r.length:i+=1;else i+=1};return o(t),i},_times:function(e,n,i){for(var o,s=new Array(n).join().split(","),r=[],l=0;l<e.length;l++){var a=e[l],h=0;for(o=0;o<a.length;o++){var c=a[o],d=c.className||"",f=c.text,g=this._innerElements(c,"rows");h+=g,c.allDay&&(d="k-scheduler-times-all-day"),i&&-1!==d.indexOf("k-scheduler-group-cell")&&(f='<span class="k-scheduler-group-text">'+f+"</span>"),s[h-g]+='<th class="'+d+'" rowspan="'+g+'">'+f+"</th>"}}for(o=0;o<n;o++)r.push(s[o]);return n<1?t():t('<div class="k-scheduler-times">'+u(r)+"</div>")},_datesHeader:function(e,n){for(var i,o=[],s=0;s<e.length;s++){var r=e[s],l=[];for(i=0;i<r.length;i++){var a=r[i],h=this._innerElements(a,"columns","colspan");l.push('<th colspan="'+(a.colspan||h)+'" class="'+(a.className||"")+'">'+a.text+"</th>")}o.push(l.join(""))}var c,d,f=[];if(n){var g=e[e.length-1],v=[],p=n.cellContent;for(i=0;i<g.length;i++)v.push('<td class="'+(g[i].className||"")+'">'+(p?p(i):"&nbsp;")+"</td>");f.push(v.join(""))}return t('<div class="k-scheduler-header"><div class="k-scheduler-header-wrap">'+u(o)+(d="k-scheduler-header-all-day",((c=f).length?"<div style='position:relative'>"+u(c,d)+"</div>":"")+"</div></div>"))},_formatEventAriaLabel:function(t,n,i,o){var s,r=this.options.messages.ariaEventLabel,l=e.date.getDate(n).getTime()===e.date.getDate(i).getTime();return"string"==typeof r?e.format(r,t,n,n):(s=(r.prefix+a+t+a+r.on+a+e.toString(n,"D")).trim(),o&&l?s+a+r.allDay:o?s+a+r.to+a+e.toString(i,"D")+a+r.allDay:(s=s+a+r.at+a+e.toString(n,"t")+a+r.to+a,l?s+e.toString(i,"t"):s+e.toString(i,"D")+a+r.at+a+e.toString(i,"t")))}});var b=function(t){var e,n,i,o,s,r=this,l=b.formats;if(1===arguments.length)for(t=r.resolveColor(t),o=0;o<l.length;o++)e=l[o].re,n=l[o].process,(i=e.exec(t))&&(s=n(i),r.r=s[0],r.g=s[1],r.b=s[2]);else r.r=arguments[0],r.g=arguments[1],r.b=arguments[2];r.r=r.normalizeByte(r.r),r.g=r.normalizeByte(r.g),r.b=r.normalizeByte(r.b)};function D(t){for(var e=[],n=0;n<t.length;n++){for(var i=t[n],o=y(i),s=null,r=0,l=e.length;r<l;r++){var a=o.start>e[r].end;if(o.start<e[r].start||a){(s=e[r]).end<o.end&&(s.end=o.end);break}}s||(s={start:o.start,end:o.end,events:[]},e.push(s)),s.events.push(i)}return e}function C(e,n,i,o){var s=[];return t.each(n,(function(t,n){var r=n.className?"k-slot-cell "+n.className:"k-slot-cell",l={text:n.text,className:r};o&&!n.minorTicks?l[e]=C(e,n.columns,i,o):l[e]=i,s.push(l)})),s}function x(n,i,o,s,r,l,a){var h=i[0],u=[];if(h){if(r&&o)t.each(r,(function(t,e){l&&!e.minorTicks?e[n]=x(n,i,e.columns,s,e.columns,l,a):e[n]=x(n,i,null,s,null,null,a)})),u=r;else{var c=h.dataSource.view();c=c.filter((function(t){var n=e.getter(h.dataParentValueField)(t);return null==n||n===a}));for(var d=0;d<c.length;d++){var f=e.getter(h.dataValueField)(c[d]),g={text:s({text:e.htmlEncode(e.getter(h.dataTextField)(c[d])),color:e.getter(h.dataColorField)(c[d]),field:h.field,title:h.title,name:h.name,value:f}),className:"k-slot-cell k-scheduler-group-cell",parentValue:a,value:f};g[n]=x(n,i.slice(1),o,s,r,l,f),u.push(g)}}return u}return o}b.prototype={resolveColor:function(t){return"#"==(t=t||"#000").charAt(0)&&(t=t.substr(1,6)),t=(t=t.replace(/ /g,"")).toLowerCase(),t=b.namedColors[t]||t},normalizeByte:function(t){return t<0||isNaN(t)?0:t>255?255:t},percBrightness:function(){var t=this;return l.sqrt(.241*t.r*t.r+.691*t.g*t.g+.068*t.b*t.b)},isDark:function(){return this.percBrightness()<180}},b.formats=[{re:/^rgb\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3})\)$/,process:function(t){return[parseInt(t[1],10),parseInt(t[2],10),parseInt(t[3],10)]}},{re:/^(\w{2})(\w{2})(\w{2})$/,process:function(t){return[parseInt(t[1],16),parseInt(t[2],16),parseInt(t[3],16)]}},{re:/^(\w{1})(\w{1})(\w{1})$/,process:function(t){return[parseInt(t[1]+t[1],16),parseInt(t[2]+t[2],16),parseInt(t[3]+t[3],16)]}}],b.namedColors={aqua:"00ffff",azure:"f0ffff",beige:"f5f5dc",black:"000000",blue:"0000ff",brown:"a52a2a",coral:"ff7f50",cyan:"00ffff",darkblue:"00008b",darkcyan:"008b8b",darkgray:"a9a9a9",darkgreen:"006400",darkorange:"ff8c00",darkred:"8b0000",dimgray:"696969",fuchsia:"ff00ff",gold:"ffd700",goldenrod:"daa520",gray:"808080",green:"008000",greenyellow:"adff2f",indigo:"4b0082",ivory:"fffff0",khaki:"f0e68c",lightblue:"add8e6",lightgrey:"d3d3d3",lightgreen:"90ee90",lightpink:"ffb6c1",lightyellow:"ffffe0",lime:"00ff00",limegreen:"32cd32",linen:"faf0e6",magenta:"ff00ff",maroon:"800000",mediumblue:"0000cd",navy:"000080",olive:"808000",orange:"ffa500",orangered:"ff4500",orchid:"da70d6",pink:"ffc0cb",plum:"dda0dd",purple:"800080",red:"ff0000",royalblue:"4169e1",salmon:"fa8072",silver:"c0c0c0",skyblue:"87ceeb",slateblue:"6a5acd",slategray:"708090",snow:"fffafa",steelblue:"4682b4",tan:"d2b48c",teal:"008080",tomato:"ff6347",turquoise:"40e0d0",violet:"ee82ee",wheat:"f5deb3",white:"ffffff",whitesmoke:"f5f5f5",yellow:"ffff00",yellowgreen:"9acd32"};var w=/\s*k-selected/;t.extend(n.SchedulerView,{createColumns:function(t){return D(t)},createRows:function(t){return D(t)},rangeIndex:y,collidingEvents:function(t,e,n){var i,o,s,r;for(i=t.length-1;i>=0;i--)s=(o=y(t[i])).start,r=o.end,(s<=e&&r>=e||s>=e&&r<=n||e<=s&&n>=s)&&(s<e&&(e=s),r>n&&(n=r));return function(t,e,n){for(var i=[],o=0;o<t.length;o++){var s=y(t[o]);(s.start<e&&s.end>e||s.start>=e&&s.end<=n)&&i.push(t[o])}return i}(t,e,n)},groupEqFilter:function(t){return function(n){if(Array.isArray(n)||n instanceof e.data.ObservableArray){for(var i=0;i<n.length;i++)if(n[i]==t)return!0;return!1}return n==t}}})}(window.kendo.jQuery);
//# sourceMappingURL=kendo.scheduler.view.js.map
