using System.Data;
using System;
using System.IO;

using System.Text;
using System.Web.UI;

using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;

namespace CBA.FlowV2.Services.Base
{
    public abstract class IPService
    {
        #region Validar
        /// <summary>
        /// Devuelve true si las direcciones de red son iguales, false en caso contrario 
        /// </summary>
        /// <param name="ipSesion">The ip sesion.</param>
        /// <param name="ipNetwork">The ip network.</param>
        /// <param name="mask">The mask.</param>
        /// <returns></returns>
        public static bool Validar(IPAddress ipSesion, IPAddress ipNetwork, IPAddress mask)
        {
            // Variables que almacenan la direccion de red segun la IP, para luego comparar 
            IPAddress network1 = GetNetworkAddress(ipSesion, mask);
            IPAddress network2 = GetNetworkAddress(ipNetwork, mask);

            return network1.Equals(network2);
        }
        #endregion Validar

        #region GetNetworkAddress
        /// <summary>
        /// Devuelve la direccion de red en forma de IPAddress, luego de efectuar el AND
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="mascara">The mascara.</param>
        /// <returns></returns>
        private static IPAddress GetNetworkAddress(IPAddress ip, IPAddress mascara)
        {
            // Pasa la direccion IP a un byte array
            byte[] ipAddressBytes = ip.GetAddressBytes();
            byte[] maskBytes = mascara.GetAddressBytes();

            // Crea un nuevo byte array para almacenar la direccion de red
            byte[] networkAddress = new byte[ipAddressBytes.Length];

            // IP & Mask. El resultado se almacena en el nuevo byte array
            for (int i = 0; i < networkAddress.Length; i++)
                networkAddress[i] = (byte)(ipAddressBytes[i] & maskBytes[i]);

            return new IPAddress(networkAddress);
        }
        #endregion GetNetworkAddress
    }
}
