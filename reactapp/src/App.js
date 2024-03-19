import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { contribuyentes: [], loading: true };
    }

    componentDidMount() {

        this.mostrarData();
    }

    static renderizarData(contribuyentes) {
        return (
            <div>
                <div className="row mb-2" style={{ paddingLeft: "17px", width: "98.3%" }}>
                    <div className="col"><b>RNC/C&eacute;dula</b></div>
                    <div className="col"><b>Nombre</b></div>
                    <div className="col"><b>Tipo</b></div>
                    <div className="col"><b>Status</b></div>
                </div>
                <div className="accordion" id="accordionExample">
                    {
                        contribuyentes.map(contribuyente =>
                            <div className="accordion-item" key={contribuyente.key}>
                                <h2 className="accordion-header">
                                    <button className="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target={"#" + contribuyente.key} aria-expanded="true" aria-controls={contribuyente.key}>
                                        <div className="row w-100">
                                            <div key={contribuyente.key} className="col">{contribuyente.rncCedula}</div>
                                            <div key={contribuyente.key} className="col">{contribuyente.nombre}</div>
                                            <div key={contribuyente.key} className="col">{contribuyente.tipo}</div>
                                            <div key={contribuyente.key} className="col">{contribuyente.status}</div>
                                        </div>
                                    </button> 
                                </h2>
                                <div id={contribuyente.key} className="accordion-collapse collapse" data-bs-parent="#accordionExample">
                                    <div className="accordion-body">
                                        {
                                            contribuyente.comprobantesFiscales.map(comprobante =>
                                                <div className="row w-100 mb-2 text-center">
                                                    <div key={comprobante.Key} className="col">{comprobante.ncf}</div>
                                                    <div key={comprobante.Key} className="col">{comprobante.itibis18}</div>
                                                </div>
                                            )
                                        }
                                        <div className="row w-100 mb-2 text-center">
                                            <div key={contribuyente.key} className="col"><b>Total</b></div>
                                            <div key={contribuyente.key} className="col">{contribuyente.totalItebis}</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )
                    }
                </div>
            </div >
        );
    }

    render() {
        let contents = this.state.loading
            ? <p>Loading... </p>
            : App.renderizarData(this.state.contribuyentes);

        return (
            <div>
                <h1 id="tabelLabel" >Listado de contribuyentes</h1>
                <p>Seleccione el contribuyente para ver m&aacute;s informaci&oacute;n.</p>
                {contents}
            </div>
        );
    }

    async mostrarData() {
        const response = await fetch('ContribuyentesComprobantes');
        const data = await response.json();
        this.setState({ contribuyentes: data, loading: false });
    }
}
