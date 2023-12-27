// <fileinfo name="ESCALAS_PREMIOSRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="ESCALAS_PREMIOSRow"/> that 
	/// represents a record in the <c>ESCALAS_PREMIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ESCALAS_PREMIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ESCALAS_PREMIOSRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _tipo_escala_premio_id;
		private decimal _porcentaje_limite_superior;
		private decimal _porcentaje_premio;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ESCALAS_PREMIOSRow_Base"/> class.
		/// </summary>
		public ESCALAS_PREMIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ESCALAS_PREMIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.TIPO_ESCALA_PREMIO_ID != original.TIPO_ESCALA_PREMIO_ID) return true;
			if (this.PORCENTAJE_LIMITE_SUPERIOR != original.PORCENTAJE_LIMITE_SUPERIOR) return true;
			if (this.PORCENTAJE_PREMIO != original.PORCENTAJE_PREMIO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ESCALA_PREMIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ESCALA_PREMIO_ID</c> column value.</value>
		public decimal TIPO_ESCALA_PREMIO_ID
		{
			get { return _tipo_escala_premio_id; }
			set { _tipo_escala_premio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_LIMITE_SUPERIOR</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_LIMITE_SUPERIOR</c> column value.</value>
		public decimal PORCENTAJE_LIMITE_SUPERIOR
		{
			get { return _porcentaje_limite_superior; }
			set { _porcentaje_limite_superior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_PREMIO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_PREMIO</c> column value.</value>
		public decimal PORCENTAJE_PREMIO
		{
			get { return _porcentaje_premio; }
			set { _porcentaje_premio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@TIPO_ESCALA_PREMIO_ID=");
			dynStr.Append(TIPO_ESCALA_PREMIO_ID);
			dynStr.Append("@CBA@PORCENTAJE_LIMITE_SUPERIOR=");
			dynStr.Append(PORCENTAJE_LIMITE_SUPERIOR);
			dynStr.Append("@CBA@PORCENTAJE_PREMIO=");
			dynStr.Append(PORCENTAJE_PREMIO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ESCALAS_PREMIOSRow_Base class
} // End of namespace
