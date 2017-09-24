import m from 'mithril'
import App from "./components/app.jsx"
import Login from "./components/login.jsx"
import "./index.styl"
import Screen from "./services/screen"

calculateBreakpoint(window)
var root = document.getElementById('app')
// m.mount(document.getElementById("app"), App)
m.route(root, '/', {
    '/': App,
    '/login': Login
})


window.addEventListener('resize', ({ target }) => {calculateBreakpoint(target)})

function calculateBreakpoint({ innerWidth }) {
    Screen.width = innerWidth
    m.redraw()  // Force a redraw, Mithril ignores resize changes on default for performance issues, never going to be a problem in a live env.
}