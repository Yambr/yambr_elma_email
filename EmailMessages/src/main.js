// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import {library} from '@fortawesome/fontawesome-svg-core'
import {
  faArrowLeft,
  faArrowRight,
  faCalendar,
  faShareAlt,
  faEyeSlash,
  faPaperPlane,
  faEye,
  faReply,
  faChevronDown,
  faChevronUp,
  faCheck
} from '@fortawesome/free-solid-svg-icons'
import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome'

library.add(faArrowLeft, faArrowRight, faCalendar, faShareAlt, faEyeSlash, faPaperPlane, faEye, faReply, faChevronDown, faChevronUp, faCheck)

Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.config.productionTip = true

window.emailMessagesInit = function (entityId, type) {
  /* eslint-disable no-new */
  return new Vue({
    el: '#app',
    components: {App},
    template: '<App v-bind:entity_id="entityId" :type="type"/>',
    data: {
      entityId: entityId,
      type:type
    }
  })
}


