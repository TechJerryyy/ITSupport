/**
 * Kendo UI v2023.1.314 (http://www.telerik.com/kendo-ui)
 * Copyright 2023 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Kendo UI commercial licenses may be obtained at
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete
 * If you do not own a commercial license, this file shall be governed by the trial license terms.
 */
import"./kendo.core.js";import"./kendo.floatinglabel.js";var __meta__={id:"textarea",name:"TextArea",category:"web",description:"The TextArea widget represents a multi-line plain-text editing control which enables you to style and provide a floating label functionality to textarea elements",depends:["core","floatinglabel"]};!function(e,a){var l=window.kendo,t=l.ui.Widget,n=l.ui,s=e.isPlainObject,o=".kendoTextArea",i="change",r="disabled",p="readonly",d="k-focus",u="k-disabled",c="k-readonly",f="aria-disabled",b=t.extend({init:function(n,s){var o=this;t.fn.init.call(o,n,s),s=e.extend(!0,{},s),o.options.value=s.value||o.element.val(),o.options.readonly=s.readonly!==a?s.readonly:Boolean(o.element.attr("readonly")),o.options.enable=s.enable!==a?s.enable:!Boolean(o.element.attr("disabled")),o.options.placeholder=s.placeholder||o.element.attr("placeholder"),o.options.value.replace(/\s/g,"").length||(o.options.value="",o.element.val("")),o.value(o.options.value),o._wrapper(),o._label(),o._editable({readonly:o.options.readonly,disable:!o.options.enable}),o._applyAttributes(),o._applyCssClasses(),o.element.addClass("k-input-inner").css("resize",o.options.resizable).attr("autocomplete","off"),l.notify(o)},events:[i],attributes:["maxLength","rows","placeholder"],options:{name:"TextArea",value:"",readonly:!1,enable:!0,placeholder:"",label:null,resizable:"none",maxLength:null,cols:20,rows:1,rounded:"medium",size:"medium",fillMode:"solid",resize:"none",overflow:"auto"},_applyCssClasses:function(e){var a=this,n=a.options,s=l.cssProperties.getValidClass({widget:n.name,propName:"resize",value:n.resize}),o=l.cssProperties.getValidClass({widget:n.name,propName:"overflow",value:n.overflow});t.fn._applyCssClasses.call(a),s||"none"!==n.resize||(s="k-resize-none"),o&&(o="!"+o),e=e||"addClass",a.wrapper[e](s),a.element[e](o)},_applyAttributes:function(){var e,a=this,l={};for(e in a.attributes)l[a.attributes[e]]=a.options[a.attributes[e]];a.element.attr(l)},value:function(e){var l=this;if(e===a)return l._value;l._value=e,l.element.val(e)},readonly:function(e){this._editable({readonly:e===a||e,disable:!1}),this.floatingLabel&&this.floatingLabel.readonly(e===a||e)},enable:function(e){this._editable({readonly:!1,disable:!(e=e===a||e)}),this.floatingLabel&&this.floatingLabel.enable(e=e===a||e)},focus:function(){this.element[0].focus()},destroy:function(){var e=this;e.floatingLabel&&e.floatingLabel.destroy(),e.element.off(o),t.fn.destroy.call(e)},setOptions:function(e){this._applyCssClasses("removeClass"),t.fn.setOptions.call(this,e)},_editable:function(e){var a=this,l=a.element,t=a.wrapper,n=e.disable,s=e.readonly;l.off(o),s||n?(l.attr(r,n).attr(p,s).attr(f,n),t.toggleClass(u,n).toggleClass(c,s)):(l.prop(r,!1).prop(p,!1).attr(f,!1),t.removeClass(u).removeClass(c),l.on("focusin"+o,a._focusin.bind(a)),l.on("focusout"+o,a._focusout.bind(a)))},_label:function(){var a,t,n=this,o=n.element,i=n.options,r=o.attr("id");null!==i.label&&(a=!!s(i.label)&&i.label.floating,t=s(i.label)?i.label.content:i.label,a&&(n._floatingLabelContainer=n.wrapper.wrap("<span></span>").parent(),n.floatingLabel=new l.ui.FloatingLabel(n._floatingLabelContainer,{widget:n,useReadOnlyClass:!0}),n._floatingLabelContainer.addClass("k-textarea-container")),l.isFunction(t)&&(t=t.call(n)),t||(t=""),r||(r=i.name+"_"+l.guid(),o.attr("id",r)),n._inputLabel=e("<label class='k-label k-input-label' for='"+r+"'>"+t+"</label>'").insertBefore(n.wrapper))},_focusin:function(){this.wrapper.addClass(d)},_focusout:function(){var e=this,a=e._value,l=e.element.val();e.wrapper.removeClass(d),null===a&&(a=""),a!==l&&(e._value=l,e.trigger(i))},_wrapper:function(){var e,a=this.element,l=a[0];(e=a.wrap("<span class='k-input k-textarea'></span>").parent())[0].style.cssText=l.style.cssText,l.style.width="100%",this.wrapper=e.addClass(l.className).removeClass("input-validation-error")}});l.cssProperties.registerPrefix("TextArea","k-input-"),l.cssProperties.registerValues("TextArea",[{prop:"rounded",values:l.cssProperties.roundedValues.concat([["full","full"]])}]),n.plugin(b)}(window.kendo.jQuery);
//# sourceMappingURL=kendo.textarea.js.map
