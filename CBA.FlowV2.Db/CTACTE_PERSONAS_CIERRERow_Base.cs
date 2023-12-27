// <fileinfo name="CTACTE_PERSONAS_CIERRERow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONAS_CIERRERow"/> that 
	/// represents a record in the <c>CTACTE_PERSONAS_CIERRE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PERSONAS_CIERRERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONAS_CIERRERow_Base
	{
		private decimal _id;
		private decimal _cotizacion;
		private System.DateTime _fecha_cierre;
		private System.DateTime _fecha_creacion;
		private decimal _cierre_anterior_id;
		private bool _cierre_anterior_idNull = true;
		private decimal _usuario_creador_id;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONAS_CIERRERow_Base"/> class.
		/// </summary>
		public CTACTE_PERSONAS_CIERRERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PERSONAS_CIERRERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.FECHA_CIERRE != original.FECHA_CIERRE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsCIERRE_ANTERIOR_IDNull != original.IsCIERRE_ANTERIOR_IDNull) return true;
			if (!this.IsCIERRE_ANTERIOR_IDNull && !original.IsCIERRE_ANTERIOR_IDNull)
				if (this.CIERRE_ANTERIOR_ID != original.CIERRE_ANTERIOR_ID) return true;
			if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CIERRE</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CIERRE</c> column value.</value>
		public System.DateTime FECHA_CIERRE
		{
			get { return _fecha_cierre; }
			set { _fecha_cierre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIERRE_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIERRE_ANTERIOR_ID</c> column value.</value>
		public decimal CIERRE_ANTERIOR_ID
		{
			get
			{
				if(IsCIERRE_ANTERIOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cierre_anterior_id;
			}
			set
			{
				_cierre_anterior_idNull = false;
				_cierre_anterior_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIERRE_ANTERIOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIERRE_ANTERIOR_IDNull
		{
			get { return _cierre_anterior_idNull; }
			set { _cierre_anterior_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get { return _usuario_creador_id; }
			set { _usuario_creador_id = value; }
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
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@FECHA_CIERRE=");
			dynStr.Append(FECHA_CIERRE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@CIERRE_ANTERIOR_ID=");
			dynStr.Append(IsCIERRE_ANTERIOR_IDNull ? (object)"<NULL>" : CIERRE_ANTERIOR_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PERSONAS_CIERRERow_Base class
} // End of namespace
