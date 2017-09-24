import m from 'mithril'
import Screen from "../services/screen.js"

export default class {
    view() {
        return <div id="main">
            <div className="container app">
                <div className="box header">
                    <h1>Keeper</h1>
                </div>
                <div className="row">
                    <h2>Hello, world</h2>
                    
                    <p>THe current route is: {m.route.get()}</p>
                </div>

                <div className="row">
                    <p>The current screen width is {Screen.width}</p>
                </div>

                <h3>Hello, world</h3>
                <h4>Hello, world</h4>
                <h5>Hello, world</h5>
                <h6>Hello, world</h6>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat nam modi, at autem accusantium dolore unde? Quasi autem asperiores voluptate iusto, vel, similique, iste illum tempora amet dignissimos officia consequuntur.</p>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat nam modi, at autem accusantium dolore unde? Quasi autem asperiores voluptate iusto, vel, similique, iste illum tempora amet dignissimos officia consequuntur.</p>
            </div>
        </div>
    }
}