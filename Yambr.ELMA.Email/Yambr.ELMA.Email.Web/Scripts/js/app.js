webpackJsonp([1],{

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

__webpack_require__("u7Vc");
module.exports = __webpack_require__("NHnr");


/***/ }),

/***/ "GXcu":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "Gcgg":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "IFSn":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "IL3w":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "NHnr":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });

// EXTERNAL MODULE: ./node_modules/vue/dist/vue.esm.js
var vue_esm = __webpack_require__("7+uW");

// EXTERNAL MODULE: ./node_modules/highcharts-vue/dist/highcharts-vue.min.js
var highcharts_vue_min = __webpack_require__("5YuA");
var highcharts_vue_min_default = /*#__PURE__*/__webpack_require__.n(highcharts_vue_min);

// EXTERNAL MODULE: ./node_modules/highcharts/highcharts.js
var highcharts = __webpack_require__("504h");
var highcharts_default = /*#__PURE__*/__webpack_require__.n(highcharts);

// EXTERNAL MODULE: ./node_modules/highcharts/modules/stock.js
var stock = __webpack_require__("WOHC");
var stock_default = /*#__PURE__*/__webpack_require__.n(stock);

// EXTERNAL MODULE: ./node_modules/babel-runtime/regenerator/index.js
var regenerator = __webpack_require__("Xxa5");
var regenerator_default = /*#__PURE__*/__webpack_require__.n(regenerator);

// EXTERNAL MODULE: ./node_modules/babel-runtime/helpers/asyncToGenerator.js
var asyncToGenerator = __webpack_require__("exGp");
var asyncToGenerator_default = /*#__PURE__*/__webpack_require__.n(asyncToGenerator);

// EXTERNAL MODULE: ./node_modules/axios/index.js
var axios = __webpack_require__("mtWM");
var axios_default = /*#__PURE__*/__webpack_require__.n(axios);

// CONCATENATED MODULE: ./src/components/api/emailStatApi.js



var emailStat = function () {
  var _ref = asyncToGenerator_default()( /*#__PURE__*/regenerator_default.a.mark(function _callee(id, type) {
    var url, data, response, chartData, index, el, date;
    return regenerator_default.a.wrap(function _callee$(_context) {
      while (1) {
        switch (_context.prev = _context.next) {
          case 0:
            url = statUri(type) + id;
            data = null;

            if (!vue_esm["a" /* default */].config.productionTip) {
              url = "http://localhost:888" + url;
            }

            _context.next = 5;
            return axios_default.a.get(url);

          case 5:
            response = _context.sent;

            data = response.data;

            chartData = [];

            for (index = 0; index < data.length; index++) {
              el = data[index];
              date = Date.UTC(el.year, el.month - 1, 1);

              chartData.push([date, el.count]);
            }
            return _context.abrupt('return', chartData);

          case 10:
          case 'end':
            return _context.stop();
        }
      }
    }, _callee, this);
  }));

  return function emailStat(_x, _x2) {
    return _ref.apply(this, arguments);
  };
}();




var baseStatUri = "/Yambr.ELMA.Email.Web/EmailStats/";
function statUri(type) {
  return baseStatUri + type + "/";
}

/* harmony default export */ var emailStatApi = ({
  emailStat: emailStat
});
// CONCATENATED MODULE: ./src/components/api/emailMessageApi.js



var deleteEmail = function () {
  var _ref = asyncToGenerator_default()( /*#__PURE__*/regenerator_default.a.mark(function _callee(id) {
    var url, data, response;
    return regenerator_default.a.wrap(function _callee$(_context) {
      while (1) {
        switch (_context.prev = _context.next) {
          case 0:
            url = baseDeleteEmailUri + id;
            data = null;

            if (!vue_esm["a" /* default */].config.productionTip) {
              url = "http://localhost:888" + url;
            }
            _context.next = 5;
            return axios_default.a.get(url);

          case 5:
            response = _context.sent;

            data = response.data;

            return _context.abrupt('return', data);

          case 8:
          case 'end':
            return _context.stop();
        }
      }
    }, _callee, this);
  }));

  return function deleteEmail(_x) {
    return _ref.apply(this, arguments);
  };
}();

var emailSearch = function () {
  var _ref2 = asyncToGenerator_default()( /*#__PURE__*/regenerator_default.a.mark(function _callee2(type, id, searchString, skip, size) {
    var url, data, response;
    return regenerator_default.a.wrap(function _callee2$(_context2) {
      while (1) {
        switch (_context2.prev = _context2.next) {
          case 0:
            url = searchEmailUri(type) + id + '?searchString=' + searchString + '&skip=' + skip + '&size=' + size;
            data = null;

            if (!vue_esm["a" /* default */].config.productionTip) {
              url = "http://localhost:888" + url;
            }
            _context2.next = 5;
            return axios_default.a.get(url);

          case 5:
            response = _context2.sent;

            data = response.data;

            return _context2.abrupt('return', data);

          case 8:
          case 'end':
            return _context2.stop();
        }
      }
    }, _callee2, this);
  }));

  return function emailSearch(_x2, _x3, _x4, _x5, _x6) {
    return _ref2.apply(this, arguments);
  };
}();

var email = function () {
  var _ref3 = asyncToGenerator_default()( /*#__PURE__*/regenerator_default.a.mark(function _callee3(type, id, from, to, skip, size) {
    var fromString, toString, url, data, response;
    return regenerator_default.a.wrap(function _callee3$(_context3) {
      while (1) {
        switch (_context3.prev = _context3.next) {
          case 0:
            fromString = from.toISOString();
            toString = to.toISOString();
            url = emailUri(type) + id + '?from=' + fromString + '&to=' + toString + '&skip=' + skip + '&size=' + size;
            data = null;

            if (!vue_esm["a" /* default */].config.productionTip) {
              url = "http://localhost:888" + url;
            }
            _context3.next = 7;
            return axios_default.a.get(url);

          case 7:
            response = _context3.sent;

            data = response.data;

            return _context3.abrupt('return', data);

          case 10:
          case 'end':
            return _context3.stop();
        }
      }
    }, _callee3, this);
  }));

  return function email(_x7, _x8, _x9, _x10, _x11, _x12) {
    return _ref3.apply(this, arguments);
  };
}();

var loadEmail = function () {
  var _ref4 = asyncToGenerator_default()( /*#__PURE__*/regenerator_default.a.mark(function _callee4(id) {
    var data, url, response;
    return regenerator_default.a.wrap(function _callee4$(_context4) {
      while (1) {
        switch (_context4.prev = _context4.next) {
          case 0:
            data = null;
            url = baseEmailUri + id;

            if (!vue_esm["a" /* default */].config.productionTip) {
              url = "http://localhost:888" + url;
            }
            _context4.next = 5;
            return axios_default.a.get(url);

          case 5:
            response = _context4.sent;

            data = response.data;
            return _context4.abrupt('return', data);

          case 8:
          case 'end':
            return _context4.stop();
        }
      }
    }, _callee4, this);
  }));

  return function loadEmail(_x13) {
    return _ref4.apply(this, arguments);
  };
}();




var baseDeleteEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Delete/";
var baseEmailUri = "/Yambr.ELMA.Email.Web/EmailMessage/Load/";

function searchEmailUri(type) {
  return "/Yambr.ELMA.Email.Web/EmailMessage/" + type + "Search/";
}

function emailUri(type) {
  return "/Yambr.ELMA.Email.Web/EmailMessage/" + type + "/";
}

/* harmony default export */ var emailMessageApi = ({
  deleteEmail: deleteEmail,
  emailSearch: emailSearch,
  email: email,
  loadEmail: loadEmail
});
// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/ParticipantHeading.vue
//
//
//
//
//
//
//

/* harmony default export */ var ParticipantHeading = ({
    name: 'ParticipantHeading',
    props: {
        participant: {},
        message: {}
    },
    computed: {
        name: function name() {
            return this.participant.name;
        },
        user: function user() {
            return this.participant.user;
        },
        contact: function contact() {
            return this.participant.contact;
        },
        email: function email() {
            return this.participant.email;
        },
        subject: function subject() {
            return this.message.subject;
        },
        contactUri: function contactUri() {
            return "/CRM/Contact/Details/" + this.contact;
        },
        userUri: function userUri() {
            return "javascript:showUserInfo(" + this.user + ")";
        },
        mailToUri: function mailToUri() {
            return "mailto:" + this.email + "?subject=" + this.subject;
        }
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-3d80fcc0","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/ParticipantHeading.vue
var render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',[((_vm.contact))?_c('a',{attrs:{"href":_vm.contactUri}},[_vm._v(_vm._s(_vm.name))]):_vm._e(),_vm._v(" "),((_vm.user))?_c('a',{attrs:{"href":_vm.userUri}},[_vm._v(_vm._s(_vm.name))]):_vm._e(),_vm._v(" "),_c('a',{staticClass:"b-message-head__email small",attrs:{"href":_vm.mailToUri}},[_vm._v("<"+_vm._s(_vm.email)+">")])])}
var staticRenderFns = []
var esExports = { render: render, staticRenderFns: staticRenderFns }
/* harmony default export */ var components_ParticipantHeading = (esExports);
// CONCATENATED MODULE: ./src/components/ParticipantHeading.vue
function injectStyle (ssrContext) {
  __webpack_require__("IL3w")
}
var normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var __vue_template_functional__ = false
/* styles */
var __vue_styles__ = injectStyle
/* scopeId */
var __vue_scopeId__ = "data-v-3d80fcc0"
/* moduleIdentifier (server only) */
var __vue_module_identifier__ = null
var Component = normalizeComponent(
  ParticipantHeading,
  components_ParticipantHeading,
  __vue_template_functional__,
  __vue_styles__,
  __vue_scopeId__,
  __vue_module_identifier__
)

/* harmony default export */ var src_components_ParticipantHeading = (Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/MessageHeading.vue
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//




function dimension(time, type) {
    // Определяем склонение единицы измерения
    var dimension = {
        'n': ['месяцев', 'месяц', 'месяца', 'месяц'],
        'j': ['дней', 'день', 'дня'],
        'G': ['часов', 'час', 'часа'],
        'i': ['минут', 'минуту', 'минуты'],
        'Y': ['лет', 'год', 'года']
    };
    var n = 0;
    if (time >= 5 && time <= 20) n = 0;else if (time == 1 || time % 10 == 1) n = 1;else if (time <= 4 && time >= 1 || time % 10 <= 4 && time % 10 >= 1) n = 2;else n = 0;
    return time + ' ' + dimension[type][n] + ' назад';
}

/* harmony default export */ var MessageHeading = ({
    name: 'MessageHeading',
    components: { ParticipantHeading: src_components_ParticipantHeading },
    props: {
        message: {},
        hideMessage: {}
    },
    computed: {
        from: function from() {
            return this.message.from;
        },
        to: function to() {
            return this.message.to;
        },
        subject: function subject() {
            return this.message.subject;
        },
        date: function date() {
            return this.message.date;
        },
        messageDate: function messageDate() {
            var date = new Date(this.message.date);
            return date.toLocaleDateString() + " " + date.getHours() + ":" + date.getMinutes();
        },
        replyHref: function replyHref() {
            return "mailto:" + this.message.from[0].email + "?subject=" + this.message.subject;
        },
        timeSince: function timeSince() {
            // Определяем количество и тип единицы измерения
            var date = new Date(this.message.date);
            var time = (new Date().getTime() - date.getTime()) / 1000;
            if (time < 60) {
                return 'меньше минуты назад';
            } else if (time < 3600) {
                return dimension(Math.floor(time / 60), 'i');
            } else if (time < 86400) {
                return dimension(Math.floor(time / 3600), 'G');
            } else if (time < 2592000) {
                return dimension(Math.floor(time / 86400), 'j');
            } else if (time < 31104000) {
                return dimension(Math.floor(time / 2592000), 'n');
            } else if (time >= 31104000) {
                return dimension(Math.floor(time / 31104000), 'Y');
            }
        }
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-50f28031","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/MessageHeading.vue
var MessageHeading_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',{staticClass:"timeline-heading"},[_c('table',{staticClass:"heading-table"},[_c('tr',[_c('td',{staticClass:"msg-desc"},[_vm._v("\n        От:\n      ")]),_vm._v(" "),_c('td',[_vm._l((_vm.from),function(participant,index){return [_c('ParticipantHeading',{attrs:{"participant":participant,"message":_vm.message}})]})],2),_vm._v(" "),_c('td',[_c('div',{staticClass:"fa-pull-right",staticStyle:{"text-align":"right"}},[_c('span',{staticClass:"b-message-head__email"},[_vm._v(_vm._s(_vm.messageDate))])])])]),_vm._v(" "),_c('tr',[_c('td',{staticClass:"msg-desc"},[_vm._v("Кому:")]),_vm._v(" "),_c('td',[_vm._l((_vm.to),function(participant,index){return [_c('ParticipantHeading',{attrs:{"participant":participant,"message":_vm.message}})]})],2),_vm._v(" "),_c('td',{staticClass:"fa-pull-right",staticStyle:{"text-align":"right"}},[_c('span',{staticClass:"b-message-head__email small"},[_vm._v(_vm._s(_vm.timeSince))])])]),_vm._v(" "),_vm._m(0),_vm._v(" "),_c('tr',[_c('td',{staticClass:"msg-desc"},[_vm._v("Тема:")]),_vm._v(" "),_c('td',[_c('b',{staticClass:"timeline-title"},[_vm._v(_vm._s(this.message.subject))]),_vm._v(" "),_c('a',{staticClass:"hide-message",attrs:{"title":"Скрыть сообщение"},on:{"click":function($event){return _vm.hideMessage()}}},[_c('font-awesome-icon',{attrs:{"icon":"eye-slash","size":"xs"}})],1)]),_vm._v(" "),_c('td',[_c('a',{staticClass:"b-message-head__email fa-pull-right",attrs:{"href":_vm.replyHref,"title":"Ответить"}},[_c('font-awesome-icon',{staticClass:"message-reply",attrs:{"icon":"reply"}})],1)])])])])}
var MessageHeading_staticRenderFns = [function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('tr',[_c('td',{attrs:{"colspan":"3"}},[_c('div',{staticClass:"divider"})])])}]
var MessageHeading_esExports = { render: MessageHeading_render, staticRenderFns: MessageHeading_staticRenderFns }
/* harmony default export */ var components_MessageHeading = (MessageHeading_esExports);
// CONCATENATED MODULE: ./src/components/MessageHeading.vue
function MessageHeading_injectStyle (ssrContext) {
  __webpack_require__("Gcgg")
}
var MessageHeading_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var MessageHeading___vue_template_functional__ = false
/* styles */
var MessageHeading___vue_styles__ = MessageHeading_injectStyle
/* scopeId */
var MessageHeading___vue_scopeId__ = "data-v-50f28031"
/* moduleIdentifier (server only) */
var MessageHeading___vue_module_identifier__ = null
var MessageHeading_Component = MessageHeading_normalizeComponent(
  MessageHeading,
  components_MessageHeading,
  MessageHeading___vue_template_functional__,
  MessageHeading___vue_styles__,
  MessageHeading___vue_scopeId__,
  MessageHeading___vue_module_identifier__
)

/* harmony default export */ var src_components_MessageHeading = (MessageHeading_Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/Message.vue
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//




/* harmony default export */ var Message = ({
    name: 'Message',
    components: { MessageHeading: src_components_MessageHeading },
    props: {
        message: {}
    },
    data: function data() {
        return {
            opened: false,
            fullMessage: null,
            isDeleted: false
        };
    },

    methods: {
        swithMessage: function swithMessage() {
            var _this = this;

            this.opened = !this.opened;
            this.fullMessage = null;
            if (this.opened) {
                emailMessageApi.loadEmail(this.message.id).then(function (value) {
                    _this.fullMessage = value.body;
                }).catch(function (reason) {
                    console.warn(reason);
                });
            }
        },
        hideMessage: function hideMessage() {
            emailMessageApi.deleteEmail(this.message.id);
            this.isDeleted = true;
        }
    },
    computed: {
        incoming: function incoming() {
            return this.message.direction === 'Incoming';
        },
        date: function date() {
            return new Date(this.message.date);
        },
        iconRotate: function iconRotate() {
            return this.opened ? 0 : 270;
        }
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-22dc924c","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/Message.vue
var Message_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('li',{class:{'timeline-inverted': _vm.incoming}},[(!_vm.incoming)?[_c('div',{staticClass:"timeline-badge success"},[(!_vm.incoming)?_c('font-awesome-icon',{attrs:{"icon":"arrow-right"}}):_vm._e()],1)]:_vm._e(),_vm._v(" "),(_vm.incoming)?[_c('div',{staticClass:"timeline-badge danger"},[(_vm.incoming)?_c('font-awesome-icon',{attrs:{"icon":"arrow-left"}}):_vm._e()],1)]:_vm._e(),_vm._v(" "),_c('div',{staticClass:"timeline-panel"},[(!_vm.isDeleted)?_c('MessageHeading',{attrs:{"message":_vm.message,"date":_vm.date,"hide-message":_vm.hideMessage}}):_vm._e(),_vm._v(" "),(!_vm.isDeleted)?_c('div',{staticClass:"timeline-body"},[_c('table',{staticStyle:{"width":"100%"}},[_c('tr',[_c('td',{staticClass:"msg-desc",staticStyle:{"vertical-align":"top"},on:{"click":function($event){return _vm.swithMessage()}}},[_c('font-awesome-icon',{staticClass:"switcher",attrs:{"icon":"chevron-down","transform":{ rotate: _vm.iconRotate }}})],1),_vm._v(" "),_c('td',[_c('div',{directives:[{name:"show",rawName:"v-show",value:(!this.opened),expression:"!this.opened"}],staticClass:"fade msg-header",domProps:{"innerHTML":_vm._s(_vm.message.mainHeader)}}),_vm._v(" "),(this.opened&&_vm.fullMessage)?_c('div',{staticClass:"msg-body",domProps:{"innerHTML":_vm._s(_vm.fullMessage)}}):_vm._e()])]),_vm._v(" "),_c('tr',{directives:[{name:"show",rawName:"v-show",value:(this.opened),expression:"this.opened"}]},[_c('td',{staticClass:"msg-desc",on:{"click":function($event){return _vm.swithMessage()}}},[_c('font-awesome-icon',{staticClass:"switcher",attrs:{"icon":"chevron-up"}})],1)])])]):_vm._e(),_vm._v(" "),(_vm.isDeleted)?_c('h4',[_vm._v("Сообщение будет удалено в течение 15 минут")]):_vm._e()],1)],2)}
var Message_staticRenderFns = []
var Message_esExports = { render: Message_render, staticRenderFns: Message_staticRenderFns }
/* harmony default export */ var components_Message = (Message_esExports);
// CONCATENATED MODULE: ./src/components/Message.vue
function Message_injectStyle (ssrContext) {
  __webpack_require__("ww5y")
}
var Message_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var Message___vue_template_functional__ = false
/* styles */
var Message___vue_styles__ = Message_injectStyle
/* scopeId */
var Message___vue_scopeId__ = "data-v-22dc924c"
/* moduleIdentifier (server only) */
var Message___vue_module_identifier__ = null
var Message_Component = Message_normalizeComponent(
  Message,
  components_Message,
  Message___vue_template_functional__,
  Message___vue_styles__,
  Message___vue_scopeId__,
  Message___vue_module_identifier__
)

/* harmony default export */ var src_components_Message = (Message_Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/TimlineDateDivider.vue
//
//
//
//
//
//
//
//
//
//

var months = "Января,Февраля,Марта,Апреля,Мая,Июня,Июля,Августа,Сентября,Октября,Ноября,Декабря".split(",");
/* harmony default export */ var TimlineDateDivider = ({
    name: 'TimlineDateDivider',
    props: {
        date: {},
        showDate: {}
    },
    computed: {
        dateOfMonth: function dateOfMonth() {
            return this.date.getDate();
        },
        monthName: function monthName() {
            return months[this.date.getMonth()];
        }
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-74e7b106","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/TimlineDateDivider.vue
var TimlineDateDivider_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('li',{staticClass:"timeline"},[_c('div',{staticClass:"timeline-badge primary"},[_c('span',{staticClass:"timeline-balloon-date-day"},[_vm._v("\n            "+_vm._s(_vm.dateOfMonth)+"\n          ")]),_vm._v(" "),_c('span',{staticClass:"timeline-balloon-date-month"},[_vm._v(_vm._s(_vm.monthName))])])])}
var TimlineDateDivider_staticRenderFns = []
var TimlineDateDivider_esExports = { render: TimlineDateDivider_render, staticRenderFns: TimlineDateDivider_staticRenderFns }
/* harmony default export */ var components_TimlineDateDivider = (TimlineDateDivider_esExports);
// CONCATENATED MODULE: ./src/components/TimlineDateDivider.vue
function TimlineDateDivider_injectStyle (ssrContext) {
  __webpack_require__("vkGo")
}
var TimlineDateDivider_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var TimlineDateDivider___vue_template_functional__ = false
/* styles */
var TimlineDateDivider___vue_styles__ = TimlineDateDivider_injectStyle
/* scopeId */
var TimlineDateDivider___vue_scopeId__ = "data-v-74e7b106"
/* moduleIdentifier (server only) */
var TimlineDateDivider___vue_module_identifier__ = null
var TimlineDateDivider_Component = TimlineDateDivider_normalizeComponent(
  TimlineDateDivider,
  components_TimlineDateDivider,
  TimlineDateDivider___vue_template_functional__,
  TimlineDateDivider___vue_styles__,
  TimlineDateDivider___vue_scopeId__,
  TimlineDateDivider___vue_module_identifier__
)

/* harmony default export */ var src_components_TimlineDateDivider = (TimlineDateDivider_Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/MessagesTimeline.vue
//
//
//
//
//
//
//
//
//
//




/* harmony default export */ var MessagesTimeline = ({
    name: 'MessagesTimeline',
    components: { TimlineDateDivider: src_components_TimlineDateDivider, Message: src_components_Message },
    props: {
        chartEnabled: {},
        messages: {}
    },
    date: function date() {
        return {
            date: null
        };
    },

    methods: {
        showDate: function showDate(message, index) {
            var messagedate = this.getDate(message);
            var showDate = false;
            if (!this.date) {
                showDate = true;
            }
            if (this.date && messagedate.getDate() != this.date.getDate()) {
                showDate = true;
            } else if (index === 0) {
                showDate = true;
            }
            this.date = messagedate;
            return showDate;
        },
        getDate: function getDate(message) {
            return new Date(message.date);
        }
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-c2e82e8e","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/MessagesTimeline.vue
var MessagesTimeline_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return (!_vm.chartEnabled)?_c('div',{staticClass:"container"},[_c('ul',{staticClass:"timeline"},[_vm._l((_vm.messages),function(message,index){return [(_vm.showDate(message, index))?_c('TimlineDateDivider',{attrs:{"date":_vm.getDate(message)}}):_vm._e(),_vm._v(" "),_c('Message',{attrs:{"message":message}})]})],2)]):_vm._e()}
var MessagesTimeline_staticRenderFns = []
var MessagesTimeline_esExports = { render: MessagesTimeline_render, staticRenderFns: MessagesTimeline_staticRenderFns }
/* harmony default export */ var components_MessagesTimeline = (MessagesTimeline_esExports);
// CONCATENATED MODULE: ./src/components/MessagesTimeline.vue
function MessagesTimeline_injectStyle (ssrContext) {
  __webpack_require__("cCuu")
}
var MessagesTimeline_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var MessagesTimeline___vue_template_functional__ = false
/* styles */
var MessagesTimeline___vue_styles__ = MessagesTimeline_injectStyle
/* scopeId */
var MessagesTimeline___vue_scopeId__ = "data-v-c2e82e8e"
/* moduleIdentifier (server only) */
var MessagesTimeline___vue_module_identifier__ = null
var MessagesTimeline_Component = MessagesTimeline_normalizeComponent(
  MessagesTimeline,
  components_MessagesTimeline,
  MessagesTimeline___vue_template_functional__,
  MessagesTimeline___vue_styles__,
  MessagesTimeline___vue_scopeId__,
  MessagesTimeline___vue_module_identifier__
)

/* harmony default export */ var src_components_MessagesTimeline = (MessagesTimeline_Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/TimelineSearch.vue
//
//
//
//
//
//

/* harmony default export */ var TimelineSearch = ({
    name: 'TimelineSearch',
    props: ['search', 'searchtext', 'searchInHistory'],
    data: function data() {
        return {
            searchstring: ''
        };
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-b7cc4682","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/TimelineSearch.vue
var TimelineSearch_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',{staticClass:"search-wrapper"},[_c('input',{directives:[{name:"model",rawName:"v-model",value:(_vm.searchstring),expression:"searchstring"}],attrs:{"type":"text","placeholder":"Поиск в переписке"},domProps:{"value":(_vm.searchstring)},on:{"input":[function($event){if($event.target.composing){ return; }_vm.searchstring=$event.target.value},_vm.search],"keydown":function($event){if(!$event.type.indexOf('key')&&_vm._k($event.keyCode,"enter",13,$event.key,"Enter")){ return null; }$event.preventDefault();return _vm.searchInHistory($event)}}}),_vm._v(" "),_c('label',[_vm._v("Нажмите ввод (enter) для поиска в истории:")])])}
var TimelineSearch_staticRenderFns = []
var TimelineSearch_esExports = { render: TimelineSearch_render, staticRenderFns: TimelineSearch_staticRenderFns }
/* harmony default export */ var components_TimelineSearch = (TimelineSearch_esExports);
// CONCATENATED MODULE: ./src/components/TimelineSearch.vue
function TimelineSearch_injectStyle (ssrContext) {
  __webpack_require__("Trks")
}
var TimelineSearch_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var TimelineSearch___vue_template_functional__ = false
/* styles */
var TimelineSearch___vue_styles__ = TimelineSearch_injectStyle
/* scopeId */
var TimelineSearch___vue_scopeId__ = "data-v-b7cc4682"
/* moduleIdentifier (server only) */
var TimelineSearch___vue_module_identifier__ = null
var TimelineSearch_Component = TimelineSearch_normalizeComponent(
  TimelineSearch,
  components_TimelineSearch,
  TimelineSearch___vue_template_functional__,
  TimelineSearch___vue_styles__,
  TimelineSearch___vue_scopeId__,
  TimelineSearch___vue_module_identifier__
)

/* harmony default export */ var src_components_TimelineSearch = (TimelineSearch_Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/TimelineHeader.vue
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//



/* harmony default export */ var TimelineHeader = ({
    name: 'TimelineHeader',
    components: { TimelineSearch: src_components_TimelineSearch },
    props: {
        count: {},
        value: {},
        callLeft: {},
        callRight: {},
        showChart: {},
        message: {},
        search: {},
        searchInHistory: {},
        searchInHistoryMode: false,
        searchtext: ''
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-c415f292","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/TimelineHeader.vue
var TimelineHeader_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',{staticClass:"timeline-movement"},[_c('table',{staticStyle:{"width":"100%"}},[_c('tr',[_c('td',[_c('TimelineSearch',{attrs:{"search":_vm.search,"searchtext":_vm.searchtext,"search-in-history":_vm.searchInHistory}})],1),_vm._v(" "),_c('td',[_c('div',{staticClass:"fa-pull-right nav-calendar"},[_c('a',{staticClass:"nav-link",on:{"click":function($event){return _vm.callLeft()}}},[_c('font-awesome-icon',{attrs:{"icon":"arrow-left","size":"2x"}})],1),_vm._v(" "),_c('a',{staticClass:"nav-link",on:{"click":function($event){return _vm.showChart()}}},[_c('font-awesome-icon',{attrs:{"icon":"calendar","size":"2x"}})],1),_vm._v(" "),_c('a',{staticClass:"nav-link",on:{"click":function($event){return _vm.callRight()}}},[_c('font-awesome-icon',{attrs:{"icon":"arrow-right","size":"2x"}})],1)])])]),_vm._v(" "),_c('tr',[_c('td',{staticClass:"b-message-head__email"},[_c('i',[_vm._v("\n          Всего: "),_c('b',[_vm._v(_vm._s(_vm.count))])])]),_vm._v(" "),_c('td',[_c('div',{staticClass:"fa-pull-right nav-calendar"},[(!_vm.searchInHistoryMode)?_c('h3',[_vm._v("\n            "+_vm._s(_vm.message)+"\n          ")]):_vm._e(),_vm._v(" "),(_vm.searchInHistoryMode)?_c('h3',[_vm._v("\n            Результаты поиска по: "),_c('i',[_vm._v("\""+_vm._s(_vm.searchtext)+"\"")])]):_vm._e()])])])])])}
var TimelineHeader_staticRenderFns = []
var TimelineHeader_esExports = { render: TimelineHeader_render, staticRenderFns: TimelineHeader_staticRenderFns }
/* harmony default export */ var components_TimelineHeader = (TimelineHeader_esExports);
// CONCATENATED MODULE: ./src/components/TimelineHeader.vue
function TimelineHeader_injectStyle (ssrContext) {
  __webpack_require__("GXcu")
}
var TimelineHeader_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var TimelineHeader___vue_template_functional__ = false
/* styles */
var TimelineHeader___vue_styles__ = TimelineHeader_injectStyle
/* scopeId */
var TimelineHeader___vue_scopeId__ = "data-v-c415f292"
/* moduleIdentifier (server only) */
var TimelineHeader___vue_module_identifier__ = null
var TimelineHeader_Component = TimelineHeader_normalizeComponent(
  TimelineHeader,
  components_TimelineHeader,
  TimelineHeader___vue_template_functional__,
  TimelineHeader___vue_styles__,
  TimelineHeader___vue_scopeId__,
  TimelineHeader___vue_module_identifier__
)

/* harmony default export */ var src_components_TimelineHeader = (TimelineHeader_Component.exports);

// EXTERNAL MODULE: ./node_modules/vue-infinite-loading/dist/vue-infinite-loading.js
var vue_infinite_loading = __webpack_require__("qK+J");
var vue_infinite_loading_default = /*#__PURE__*/__webpack_require__.n(vue_infinite_loading);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/components/Timeline.vue
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//










stock_default()(highcharts_default.a);
var lang = {
    loading: "Loading...",
    months: "Январь,Февраль,Март,Апрель,Май,Июнь,Июль,Август,Сентябрь,Октябрь,Ноябрь,Декабрь".split(","),
    shortMonths: "Янв,Фев,Мар,Апр,Май,Июн,Июл,Авг,Сен,Окт,Ноя,Дек".split(","),
    weekdays: "Воскресенье,Понедельник,Вторник,Среда,Четверг,Пятница,Суббота".split(","),
    decimalPoint: ".",
    numericSymbols: " т.р., млн.р., млрд.р., трлд.р., трлл.р.,E".split(","),
    resetZoom: "Сбросить масштаб",
    resetZoomTitle: "Сбросить масштаб 1:1",
    thousandsSep: " "
};
highcharts_default.a.setOptions({
    lang: lang
});

/* harmony default export */ var Timeline = ({
    props: ["entity_id", "from_date", "to_date", "type"],
    name: "Timeline",
    components: {
        TimelineHeader: src_components_TimelineHeader,
        MessagesTimeline: src_components_MessagesTimeline,
        highcharts: highcharts_vue_min["Chart"],
        InfiniteLoading: vue_infinite_loading_default.a
    },
    data: function data() {
        return {
            chartOptions: this.defaultChartOptions(),
            showChart: null,
            messages: [],
            searchtext: '',
            searchInHistoryMode: false,
            filterCache: {},
            filteredMessages: [],
            from: this.from_date,
            to: this.to_date,
            skip: 0,
            skipSearch: 0,
            size: 10,
            count: 0
        };
    },

    computed: {
        chartEnabled: function chartEnabled() {
            if (this.showChart != null) {
                return this.showChart;
            }
            if (this.count > 0) {
                return false;
            }
            var b = !!this.chartOptions.series;
            return b;
        },
        hasInSelectedMonth: function hasInSelectedMonth() {
            if (this.showChart) {
                return false;
            }
            return this.count > 0;
        },
        msg: function msg() {
            var selectedDate = new Date(this.from);
            return lang.months[selectedDate.getMonth()] + " " + selectedDate.getFullYear();
        },
        renderedMesages: function renderedMesages() {
            if (!!this.searchtext && this.searchtext.length > 2) {
                return this.filteredMessages;
            } else {
                return this.messages;
            }
        }
    },
    mounted: function mounted() {
        var _this = this;

        emailStatApi.emailStat(this.entity_id, this.type).then(function (value) {
            var newChartOptions = _this.defaultChartOptions();
            newChartOptions.series = {
                data: value
            };
            _this.chartOptions = newChartOptions;
        }).catch(function (reason) {
            console.warn(reason);
        });
        emailMessageApi.email(this.type, this.entity_id, new Date(this.from), new Date(this.to), this.skip, this.size).then(function (value) {
            _this.messages = value.messages;
            _this.from = +new Date(value.from);
            _this.to = +new Date(value.to);
            _this.skip = value.skip;
            _this.count = value.count;
        }).catch(function (reason) {
            console.warn(reason);
        });
    },

    methods: {
        resetSearch: function resetSearch() {
            this.filterCache = {};
            this.searchtext = '';
            this.filteredMessages = [];
            this.searchInHistoryMode = false;
            console.log(this.searchInHistoryMode);
        },
        searchInHistory: function searchInHistory(e) {
            this.resetSearch();
            this.searchInHistoryMode = true;
            console.log(this.searchInHistoryMode);
            var searchText = e.target.value.trim().toLowerCase();
            this.searchtext = searchText;
            if (searchText && searchText.length > 2) {
                this.searchMove(searchText, 0);
            } else {
                this.resetSearch();
            }
        },
        search: function search(e) {
            var searchText = e.target.value.trim().toLowerCase();
            this.searchtext = searchText;
            if (searchText && searchText.length > 2) {
                if (this.filterCache[searchText]) {
                    this.filteredMessages = this.filterCache[searchText];
                } else {
                    var filtered = this.messages.filter(function (message) {
                        return message.subject && message.subject.toLowerCase().indexOf(searchText) > 0 || message.mainHeader && message.mainHeader.toLowerCase().indexOf(searchText) > 0;
                    });
                    this.filterCache[searchText] = filtered;
                    this.filteredMessages = filtered;
                }
            } else {
                this.resetSearch();
            }
        },
        infiniteHandler: function infiniteHandler($state) {
            if (this.searchInHistoryMode) {
                this.searchMove(this.searchtext, this.skipSearch + this.size, $state);
            } else {
                this.move(this.from, this.to, this.skip + this.size, $state);
            }
        },
        showChartClick: function showChartClick() {
            this.resetSearch();
            this.showChart = !this.chartEnabled;
        },
        openColumn: function openColumn(clickEvent) {
            this.resetSearch();
            var from = clickEvent.point.x;
            var fromAsDate = new Date(from);
            var to = +fromAsDate.setMonth(fromAsDate.getMonth() + 1);
            this.move(from, to, 0);
        },

        callLeft: function callLeft() {
            var fromAsDate = new Date(this.from);
            var toAsDate = new Date(this.to);
            var from = +fromAsDate.setMonth(fromAsDate.getMonth() - 1);
            var to = +toAsDate.setMonth(toAsDate.getMonth() - 1);
            this.move(from, to, 0);
        },

        callRight: function callRight() {
            var fromAsDate = new Date(this.from);
            var toAsDate = new Date(this.to);
            var from = +fromAsDate.setMonth(fromAsDate.getMonth() + 1);
            var to = +toAsDate.setMonth(toAsDate.getMonth() + 1);
            this.move(from, to, 0);
        },

        searchMove: function searchMove(searchString, skip, $state) {
            var _this2 = this;

            emailMessageApi.emailSearch(this.type, this.entity_id, searchString, skip, this.size).then(function (value) {
                if (skip > 0) {
                    _this2.filteredMessages = _this2.messages.concat(value.messages);
                } else {
                    _this2.filteredMessages = value.messages;
                }
                _this2.skipSearch = value.skip;
                _this2.count = value.count;
                _this2.showChart = null;
                if ($state) {
                    if (_this2.skipSearch + _this2.size < _this2.count) {
                        $state.loaded();
                    } else {
                        $state.complete();
                    }
                }
            }).catch(function (reason) {
                console.warn(reason);
            });
        },
        move: function move(from, to, skip, $state) {
            var _this3 = this;

            this.resetSearch();
            emailMessageApi.email(this.type, this.entity_id, new Date(from), new Date(to), skip, this.size).then(function (value) {
                if (skip > 0) {
                    _this3.messages = _this3.messages.concat(value.messages);
                } else {
                    _this3.messages = value.messages;
                }
                _this3.from = +new Date(value.from);
                _this3.to = +new Date(value.to);
                _this3.skip = value.skip;
                _this3.count = value.count;
                _this3.showChart = null;
                if ($state) {
                    if (_this3.skip + _this3.size < _this3.count) {
                        $state.loaded();
                    } else {
                        $state.complete();
                    }
                }
            }).catch(function (reason) {
                console.warn(reason);
            });
        },

        defaultChartOptions: function defaultChartOptions() {
            return {
                chart: {
                    type: 'column',
                    style: { "fontFamily": "Tahoma, Arial, Helvetica, sans-serif" },
                    alignTicks: false
                },
                navigator: {
                    enabled: false
                },
                scrollbar: {
                    enabled: false
                },
                rangeSelector: {
                    enabled: false
                },
                title: {
                    text: "Статистика переписки"
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '<span style="font-weight: 500"><b>{point.y}<b/></span>',
                            style: {
                                fontWeight: 500
                            }
                        },
                        point: {
                            events: {
                                click: this.openColumn
                            }
                        }
                    }
                },
                tooltip: {
                    pointFormat: '<span style="color:{point.color}">{point.money}</span><b>{point.y}</b>'
                },
                series: null
            };
        }

    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-0f1c35c6","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/components/Timeline.vue
var Timeline_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',[_c('TimelineHeader',{attrs:{"count":_vm.count,"call-left":_vm.callLeft,"call-right":_vm.callRight,"show-chart":_vm.showChartClick,"message":_vm.msg,"search":_vm.search,"searchtext":_vm.searchtext,"search-in-history":_vm.searchInHistory,"search-in-history-mode":_vm.searchInHistoryMode}}),_vm._v(" "),_c('transition',{attrs:{"name":"fade"}},[_c('div',{directives:[{name:"show",rawName:"v-show",value:(!_vm.chartEnabled),expression:"!chartEnabled"}]},[_c('MessagesTimeline',{attrs:{"chart-enabled":_vm.chartEnabled,"messages":_vm.renderedMesages}})],1)]),_vm._v(" "),_c('highcharts',{directives:[{name:"show",rawName:"v-show",value:(_vm.chartEnabled),expression:"chartEnabled"}],attrs:{"constructor-type":'stockChart',"options":_vm.chartOptions}}),_vm._v(" "),_c('infinite-loading',{directives:[{name:"show",rawName:"v-show",value:(_vm.hasInSelectedMonth),expression:"hasInSelectedMonth"}],attrs:{"identifier":_vm.from},on:{"infinite":_vm.infiniteHandler}},[_c('div',{attrs:{"slot":"no-more"},slot:"no-more"},[_c('font-awesome-icon',{staticClass:"success",attrs:{"icon":"check","size":"2x"}})],1),_vm._v(" "),_c('div',{attrs:{"slot":"no-results"},slot:"no-results"},[_c('font-awesome-icon',{staticClass:"success",attrs:{"icon":"check","size":"2x"}})],1)])],1)}
var Timeline_staticRenderFns = []
var Timeline_esExports = { render: Timeline_render, staticRenderFns: Timeline_staticRenderFns }
/* harmony default export */ var components_Timeline = (Timeline_esExports);
// CONCATENATED MODULE: ./src/components/Timeline.vue
function Timeline_injectStyle (ssrContext) {
  __webpack_require__("IFSn")
}
var Timeline_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var Timeline___vue_template_functional__ = false
/* styles */
var Timeline___vue_styles__ = Timeline_injectStyle
/* scopeId */
var Timeline___vue_scopeId__ = "data-v-0f1c35c6"
/* moduleIdentifier (server only) */
var Timeline___vue_module_identifier__ = null
var Timeline_Component = Timeline_normalizeComponent(
  Timeline,
  components_Timeline,
  Timeline___vue_template_functional__,
  Timeline___vue_styles__,
  Timeline___vue_scopeId__,
  Timeline___vue_module_identifier__
)

/* harmony default export */ var src_components_Timeline = (Timeline_Component.exports);

// CONCATENATED MODULE: ./node_modules/babel-loader/lib!./node_modules/vue-loader/lib/selector.js?type=script&index=0!./src/App.vue
//
//
//
//
//
//



/* harmony default export */ var App = ({
    name: 'App',
    components: {
        Timeline: src_components_Timeline
    },
    props: ['entity_id', 'type'],
    data: function data() {
        var fromAsDate = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
        var from = +fromAsDate;
        var to = +fromAsDate.setMonth(fromAsDate.getMonth() + 1);
        return {
            msg: 'Welcome to Your Vue.js App',
            from: from,
            to: to
        };
    }
});
// CONCATENATED MODULE: ./node_modules/vue-loader/lib/template-compiler?{"id":"data-v-da109a40","hasScoped":true,"transformToRequire":{"video":["src","poster"],"source":"src","img":"src","image":"xlink:href"},"buble":{"transforms":{}}}!./node_modules/vue-loader/lib/selector.js?type=template&index=0!./src/App.vue
var App_render = function () {var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;return _c('div',{attrs:{"id":"app"}},[_c('Timeline',{attrs:{"entity_id":_vm.entity_id,"from_date":_vm.from,"to_date":_vm.to,"type":_vm.type}})],1)}
var App_staticRenderFns = []
var App_esExports = { render: App_render, staticRenderFns: App_staticRenderFns }
/* harmony default export */ var selectortype_template_index_0_src_App = (App_esExports);
// CONCATENATED MODULE: ./src/App.vue
function App_injectStyle (ssrContext) {
  __webpack_require__("wzdV")
}
var App_normalizeComponent = __webpack_require__("VU/8")
/* script */


/* template */

/* template functional */
var App___vue_template_functional__ = false
/* styles */
var App___vue_styles__ = App_injectStyle
/* scopeId */
var App___vue_scopeId__ = "data-v-da109a40"
/* moduleIdentifier (server only) */
var App___vue_module_identifier__ = null
var App_Component = App_normalizeComponent(
  App,
  selectortype_template_index_0_src_App,
  App___vue_template_functional__,
  App___vue_styles__,
  App___vue_scopeId__,
  App___vue_module_identifier__
)

/* harmony default export */ var src_App = (App_Component.exports);

// EXTERNAL MODULE: ./node_modules/@fortawesome/fontawesome-svg-core/index.es.js
var index_es = __webpack_require__("C/JF");

// EXTERNAL MODULE: ./node_modules/@fortawesome/free-solid-svg-icons/index.es.js
var free_solid_svg_icons_index_es = __webpack_require__("fhbW");

// EXTERNAL MODULE: ./node_modules/@fortawesome/vue-fontawesome/index.es.js
var vue_fontawesome_index_es = __webpack_require__("1e6/");

// CONCATENATED MODULE: ./src/main.js
// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.






index_es["c" /* library */].add(free_solid_svg_icons_index_es["a" /* faArrowLeft */], free_solid_svg_icons_index_es["b" /* faArrowRight */], free_solid_svg_icons_index_es["c" /* faCalendar */], free_solid_svg_icons_index_es["k" /* faShareAlt */], free_solid_svg_icons_index_es["h" /* faEyeSlash */], free_solid_svg_icons_index_es["i" /* faPaperPlane */], free_solid_svg_icons_index_es["g" /* faEye */], free_solid_svg_icons_index_es["j" /* faReply */], free_solid_svg_icons_index_es["e" /* faChevronDown */], free_solid_svg_icons_index_es["f" /* faChevronUp */], free_solid_svg_icons_index_es["d" /* faCheck */]);

vue_esm["a" /* default */].component('font-awesome-icon', vue_fontawesome_index_es["a" /* FontAwesomeIcon */]);

vue_esm["a" /* default */].config.productionTip = true;

window.emailMessagesInit = function (entityId, type) {
  /* eslint-disable no-new */
  return new vue_esm["a" /* default */]({
    el: '#app',
    components: { App: src_App },
    template: '<App v-bind:entity_id="entityId" :type="type"/>',
    data: {
      entityId: entityId,
      type: type
    }
  });
};

/***/ }),

/***/ "Trks":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "cCuu":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "vkGo":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "ww5y":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ "wzdV":
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ })

},[0]);
//# sourceMappingURL=app.js.map