import m from "mithril"

export default class {

    FormData = {}
    
    view() {
        return <main>
            <form oninput={this.input.bind(this)} onsubmit={this.submit.bind(this)}>
            <input type="text" name="name" placeholder="Username"/>
            <input type="password" name="password"/>
            <input type="submit" value="Login"/>
          </form>
        </main>
    }

    submit(e) {
        e.preventDefault();
        debugger
    }

    input(e) {
        const { target: { name, value } } = e
        this.FormData[name] = value
    }

}