/**
 * Kendo UI v2023.1.314 (http://www.telerik.com/kendo-ui)
 * Copyright 2023 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";import"./kendo.icons.js";var __meta__={id:"columnsorter",name:"Column Sorter",category:"framework",depends:["core","icons"],advanced:!0};!function(e,t){var r=window.kendo,n=r.ui,i=n.Widget,o="dir",s="asc",a="single",l="mixed",d="field",c="desc",f=".kendoColumnSorter",k=".k-link",m="aria-sort",p=i.extend({init:function(e,t){var r,n=this;i.fn.init.call(n,e,t),n._refreshHandler=n.refresh.bind(n),n.dataSource=n.options.dataSource.bind("change",n._refreshHandler),n.directions=n.options.initialDirection===s?[s,c]:[c,s],(r=n.element.find(k))[0]||(r=n.element.wrapInner('<a class="k-link" href="#"/>').find(k)),n.link=r,n.element.on("click"+f,n._click.bind(n))},options:{name:"ColumnSorter",mode:a,allowUnsort:!0,compare:null,filter:"",initialDirection:s,showIndexes:!1},events:["change"],destroy:function(){var e=this;i.fn.destroy.call(e),e.element.off(f),e.dataSource.unbind("change",e._refreshHandler),e._refreshHandler=e.element=e.link=e.dataSource=null},refresh:function(n){if(!n||"itemchange"!==n.action&&"sync"!==n.action){var i,a,l,f,k,p,h,u,g=this,v=g.dataSource.sort()||[],S=g.element,_=S.attr(r.attr(d)),w=(g.dataSource._sortFields||{})[_];S.removeAttr(r.attr(o)),S.removeAttr(m),w&&(i=w.dir,S.attr(r.attr(o),i),f=w.index),S.is("th")&&w&&(a=function(e){var t=null;e.is("th")&&((t=e.closest("table")).parent().hasClass("k-grid-header-wrap")?t=t.closest(".k-grid").find(".k-grid-content > table"):t.parent().hasClass("k-grid-header-locked")&&(t=t.closest(".k-grid").find(".k-grid-content-locked > table")));return t}(S),a&&(S.attr(r.attr("index"))?(k=S.closest("table"),p=k.find("tr:not(.k-filter-row)"),h=r.attr("index"),(u=p.find("th["+h+"]:visible")).sort((function(r,n){r=e(r),n=e(n);var i=r.attr(h),o=n.attr(h);return i===t&&(i=e(r).index()),o===t&&(o=e(n).index()),(i=parseInt(i,10))>(o=parseInt(o,10))?1:i<o?-1:0})),l=u.index(S)):l=S.parent().children(":visible").index(S),a.find("col:not(.k-group-col):not(.k-hierarchy-col)").eq(l).toggleClass("k-sorted",i!==t))),S.toggleClass("k-sorted",i!==t),S.find(".k-i-sort-asc-small,.k-i-sort-desc-small,.k-svg-i-sort-asc-small,.k-svg-i-sort-desc-small,.k-sort-order,.k-sort-icon").remove(),i===s?(e('<span class="k-sort-icon">'+r.ui.icon("sort-asc-small")+"</span>").appendTo(g.link),S.attr(m,"ascending")):i===c&&(e('<span class="k-sort-icon">'+r.ui.icon("sort-desc-small")+"</span>").appendTo(g.link),S.attr(m,"descending")),g.options.showIndexes&&v.length>1&&f&&e('<span class="k-sort-order" />').html(f).appendTo(g.link)}},_toggleSortDirection:function(e){var r=this.directions;return e===r[r.length-1]&&this.options.allowUnsort?t:r[0]===e?r[1]:r[0]},_click:function(e){var n,i,s=this,c=s.element,f=c.attr(r.attr(d)),k=c.attr(r.attr(o)),m=s.options,p=null===s.options.compare?t:s.options.compare,h=s.dataSource.sort()||[],u=e.ctrlKey||e.metaKey;if(e.preventDefault(),(!m.filter||c.is(m.filter))&&(k=this._toggleSortDirection(k),!this.trigger("change",{sort:{field:f,dir:k,compare:p}}))){if(m.mode===a||m.mode===l&&!u)h=[{field:f,dir:k,compare:p}];else if("multiple"===m.mode||m.mode===l&&u){for(n=0,i=h.length;n<i;n++)if(h[n].field===f){h.splice(n,1);break}h.push({field:f,dir:k,compare:p})}this.dataSource.options.endless&&c.closest(".k-grid").getKendoGrid()._resetEndless(),this.dataSource.sort(h)}}});n.plugin(p)}(window.kendo.jQuery);
//# sourceMappingURL=kendo.columnsorter.js.map
