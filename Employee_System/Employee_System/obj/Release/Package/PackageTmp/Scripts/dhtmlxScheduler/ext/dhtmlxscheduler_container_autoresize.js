/*
@license
dhtmlxScheduler.Net v.3.3.16 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){e.config.container_autoresize=!0,e.config.month_day_min_height=90,e.config.min_grid_size=25,e.config.min_map_size=400;var t=e._pre_render_events,i=!0,n=0,a=0;e._pre_render_events=function(s,r){if(!e.config.container_autoresize||!i)return t.apply(this,arguments);var d=this.xy.bar_height,o=this._colsS.heights,l=this._colsS.heights=[0,0,0,0,0,0,0],_=this._els.dhx_cal_data[0];if(s=this._table_view?this._pre_render_events_table(s,r):this._pre_render_events_line(s,r),
this._table_view)if(r)this._colsS.heights=o;else{var h=_.firstChild;if(h.rows){for(var c=0;c<h.rows.length;c++){if(l[c]++,l[c]*d>this._colsS.height-this.xy.month_head_height){var u=h.rows[c].cells,g=this._colsS.height-this.xy.month_head_height;1*this.config.max_month_events!==this.config.max_month_events||l[c]<=this.config.max_month_events?g=l[c]*d:(this.config.max_month_events+1)*d>this._colsS.height-this.xy.month_head_height&&(g=(this.config.max_month_events+1)*d);for(var f=0;f<u.length;f++)u[f].childNodes[1].style.height=g+"px";

l[c]=(l[c-1]||0)+u[0].offsetHeight}l[c]=(l[c-1]||0)+h.rows[c].cells[0].offsetHeight}l.unshift(0),h.parentNode.offsetHeight<h.parentNode.scrollHeight&&!h._h_fix}else if(s.length||"visible"!=this._els.dhx_multi_day[0].style.visibility||(l[0]=-1),s.length||-1==l[0]){var v=(h.parentNode.childNodes,(l[0]+1)*d+1);a!=v+1&&(this._obj.style.height=n-a+v-1+"px"),v+="px",_.style.top=this._els.dhx_cal_navline[0].offsetHeight+this._els.dhx_cal_header[0].offsetHeight+parseInt(v,10)+"px",_.style.height=this._obj.offsetHeight-parseInt(_.style.top,10)-(this.xy.margin_top||0)+"px";

var m=this._els.dhx_multi_day[0];m.style.height=v,m.style.visibility=-1==l[0]?"hidden":"visible",m=this._els.dhx_multi_day[1],m.style.height=v,m.style.visibility=-1==l[0]?"hidden":"visible",m.className=l[0]?"dhx_multi_day_icon":"dhx_multi_day_icon_small",this._dy_shift=(l[0]+1)*d,l[0]=0}}return s};var s=["dhx_cal_navline","dhx_cal_header","dhx_multi_day","dhx_cal_data"],r=function(t){n=0;for(var i=0;i<s.length;i++){var r=s[i],d=e._els[r]?e._els[r][0]:null,o=0;switch(r){case"dhx_cal_navline":case"dhx_cal_header":
o=parseInt(d.style.height,10);break;case"dhx_multi_day":o=d?d.offsetHeight-1:0,a=o;break;case"dhx_cal_data":var l=e.getState().mode;if(o=d.childNodes[1]&&"month"!=l?d.childNodes[1].offsetHeight:Math.max(d.offsetHeight-1,d.scrollHeight),"month"==l){if(e.config.month_day_min_height&&!t){var _=d.getElementsByTagName("tr").length;o=_*e.config.month_day_min_height}t&&(d.style.height=o+"px")}else if("year"==l)o=190*e.config.year_y;else if("agenda"==l){if(o=0,d.childNodes&&d.childNodes.length)for(var h=0;h<d.childNodes.length;h++)o+=d.childNodes[h].offsetHeight;

o+2<e.config.min_grid_size?o=e.config.min_grid_size:o+=2}else if("week_agenda"==l){for(var c,u,g=e.xy.week_agenda_scale_height+e.config.min_grid_size,f=0;f<d.childNodes.length;f++){u=d.childNodes[f];for(var h=0;h<u.childNodes.length;h++){for(var v=0,m=u.childNodes[h].childNodes[1],p=0;p<m.childNodes.length;p++)v+=m.childNodes[p].offsetHeight;c=v+e.xy.week_agenda_scale_height,c=1!=f||2!=h&&3!=h?c:2*c,c>g&&(g=c)}}o=3*g}else if("map"==l){o=0;for(var x=d.querySelectorAll(".dhx_map_line"),h=0;h<x.length;h++)o+=x[h].offsetHeight;

o+2<e.config.min_map_size?o=e.config.min_map_size:o+=2}else if(e._gridView)if(o=0,d.childNodes[1].childNodes[0].childNodes&&d.childNodes[1].childNodes[0].childNodes.length){for(var x=d.childNodes[1].childNodes[0].childNodes[0].childNodes,h=0;h<x.length;h++)o+=x[h].offsetHeight;o+=2,o<e.config.min_grid_size&&(o=e.config.min_grid_size)}else o=e.config.min_grid_size;if(e.matrix&&e.matrix[l])if(t)o+=2,d.style.height=o+"px";else{o=2;for(var b=e.matrix[l],y=b.y_unit,w=0;w<y.length;w++)o+=y[w].children?b.folder_dy||b.dy:b.dy;

}("day"==l||"week"==l||e._props&&e._props[l])&&(o+=2)}n+=o}e._obj.style.height=n+"px",t||e.updateView()},d=function(){if(!e.config.container_autoresize||!i)return!0;var t=e.getState().mode;r(),(e.matrix&&e.matrix[t]||"month"==t)&&window.setTimeout(function(){r(!0)},1)};e.attachEvent("onViewChange",d),e.attachEvent("onXLE",d),e.attachEvent("onEventChanged",d),e.attachEvent("onEventCreated",d),e.attachEvent("onEventAdded",d),e.attachEvent("onEventDeleted",d),e.attachEvent("onAfterSchedulerResize",d),
e.attachEvent("onClearAll",d),e.attachEvent("onBeforeExpand",function(){return i=!1,!0}),e.attachEvent("onBeforeCollapse",function(){return i=!0,!0})}()});