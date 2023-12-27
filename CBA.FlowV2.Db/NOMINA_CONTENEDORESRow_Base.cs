// <fileinfo name="NOMINA_CONTENEDORESRow_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENEDORESRow"/> that 
	/// represents a record in the <c>NOMINA_CONTENEDORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOMINA_CONTENEDORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENEDORESRow_Base
	{
		private decimal _id;
		private string _booking;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _usuario_creador_id;
		private bool _usuario_creador_idNull = true;
		private decimal _usuario_modificacion_id;
		private bool _usuario_modificacion_idNull = true;
		private string _observacion;
		private string _tipo_nomina;
		private decimal _puerto_devolucion_id;
		private bool _puerto_devolucion_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENEDORESRow_Base"/> class.
		/// </summary>
		public NOMINA_CONTENEDORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOMINA_CONTENEDORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.BOOKING != original.BOOKING) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsUSUARIO_CREADOR_IDNull != original.IsUSUARIO_CREADOR_IDNull) return true;
			if (!this.IsUSUARIO_CREADOR_IDNull && !original.IsUSUARIO_CREADOR_IDNull)
				if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.IsUSUARIO_MODIFICACION_IDNull != original.IsUSUARIO_MODIFICACION_IDNull) return true;
			if (!this.IsUSUARIO_MODIFICACION_IDNull && !original.IsUSUARIO_MODIFICACION_IDNull)
				if (this.USUARIO_MODIFICACION_ID != original.USUARIO_MODIFICACION_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.TIPO_NOMINA != original.TIPO_NOMINA) return true;
			if (this.IsPUERTO_DEVOLUCION_IDNull != original.IsPUERTO_DEVOLUCION_IDNull) return true;
			if (!this.IsPUERTO_DEVOLUCION_IDNull && !original.IsPUERTO_DEVOLUCION_IDNull)
				if (this.PUERTO_DEVOLUCION_ID != original.PUERTO_DEVOLUCION_ID) return true;
			
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
		/// Gets or sets the <c>BOOKING</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BOOKING</c> column value.</value>
		public string BOOKING
		{
			get { return _booking; }
			set { _booking = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get
			{
				if(IsUSUARIO_CREADOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creador_id;
			}
			set
			{
				_usuario_creador_idNull = false;
				_usuario_creador_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREADOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREADOR_IDNull
		{
			get { return _usuario_creador_idNull; }
			set { _usuario_creador_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MODIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION_ID</c> column value.</value>
		public decimal USUARIO_MODIFICACION_ID
		{
			get
			{
				if(IsUSUARIO_MODIFICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_modificacion_id;
			}
			set
			{
				_usuario_modificacion_idNull = false;
				_usuario_modificacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_MODIFICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_MODIFICACION_IDNull
		{
			get { return _usuario_modificacion_idNull; }
			set { _usuario_modificacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NOMINA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NOMINA</c> column value.</value>
		public string TIPO_NOMINA
		{
			get { return _tipo_nomina; }
			set { _tipo_nomina = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_DEVOLUCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_DEVOLUCION_ID</c> column value.</value>
		public decimal PUERTO_DEVOLUCION_ID
		{
			get
			{
				if(IsPUERTO_DEVOLUCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerto_devolucion_id;
			}
			set
			{
				_puerto_devolucion_idNull = false;
				_puerto_devolucion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTO_DEVOLUCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTO_DEVOLUCION_IDNull
		{
			get { return _puerto_devolucion_idNull; }
			set { _puerto_devolucion_idNull = value; }
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
			dynStr.Append("@CBA@BOOKING=");
			dynStr.Append(BOOKING);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(IsUSUARIO_CREADOR_IDNull ? (object)"<NULL>" : USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@USUARIO_MODIFICACION_ID=");
			dynStr.Append(IsUSUARIO_MODIFICACION_IDNull ? (object)"<NULL>" : USUARIO_MODIFICACION_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TIPO_NOMINA=");
			dynStr.Append(TIPO_NOMINA);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_ID=");
			dynStr.Append(IsPUERTO_DEVOLUCION_IDNull ? (object)"<NULL>" : PUERTO_DEVOLUCION_ID);
			return dynStr.ToString();
		}
	} // End of NOMINA_CONTENEDORESRow_Base class
} // End of namespace
