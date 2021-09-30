using NAV;
using System;

namespace MPIntranet.WS
{
    public class BCServicesBase
    {

        public void Aggiu8ngiComponente(string NoDistinta, string descrizione, string NoComponente, string versione, )
        {
            CambiaStatoDB(NoDistinta, Stato.InSviluppo);

            RigheDIBA componente = new RigheDIBA();
            componente.No = NoComponente;
            componente.Version_Code = versione;
            componente.Description = descrizione;
            componente.Production_BOM_No = NoDistinta;
            _nav.AddToRigheDIBA(componente);

            Salva();
            CambiaStatoDB(NoDistinta, Stato.Certificato);

        }

        private void CambiaStatoDB(string noDistinta, string inSviluppo)
        {
            throw new NotImplementedException();
        }
    }
}