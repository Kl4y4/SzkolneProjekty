
class DeckBlock extends HTMLElement {

    constructor() {
        super();

        this.attachShadow({mode: 'open'});

    }

    connectedCallback() {

        const wrapper = document.createElement('div');
        wrapper.setAttribute('class', 'wrapper');
        const imgContainer = wrapper.appendChild(document.createElement('div'));
        imgContainer.setAttribute('class', 'photo');

        const img = imgContainer.appendChild(document.createElement('img'));
        img.setAttribute('class', 'deckImg');
        img.src = this.hasAttribute('photo') ? this.getAttribute('photo') : 'images/default.png';
        // img.src = this.getAttribute('photo');

        const info = wrapper.appendChild(document.createElement('div'));
        info.setAttribute('class','info');
        
        let deckName = this.hasAttribute('deck-name') ? this.getAttribute('deck-name') : 'N/A';
        let deckPrice = this.hasAttribute('deck-price') ? this.getAttribute('deck-price') : 'N/A';
        // let deckName = this.getAttribute('deck-name');
        // let deckPrice = this.getAttribute('deck-price');

        const p1 = info.appendChild(document.createElement('p'));
        const p2 = info.appendChild(document.createElement('p'));

        p1.textContent = deckName;
        p2.textContent = deckPrice;


        // Create some CSS to apply to the shadow DOM
        const style = document.createElement('style');
        style.textContent = `.wrapper { width: 100px; height: 100px; } .imgContainer { width: 100%; height: 80%; } .deckImg { height: 100%; width: 100%; } .info { display: flex; flex-direction: row; justify-content: space-around; }`;

        this.shadowRoot.append(style, wrapper);

    }
    
}

customElements.define('deck-block', DeckBlock);
