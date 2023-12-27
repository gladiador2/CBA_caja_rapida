// <fileinfo name="FICHAS_MEDICARow_Base.cs">
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
	/// The base class for <see cref="FICHAS_MEDICARow"/> that 
	/// represents a record in the <c>FICHAS_MEDICA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FICHAS_MEDICARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FICHAS_MEDICARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _paciente;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _edad_paciente;
		private bool _edad_pacienteNull = true;
		private decimal _peso_paciente;
		private bool _peso_pacienteNull = true;
		private System.DateTime _fecha;
		private bool _fechaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FICHAS_MEDICARow_Base"/> class.
		/// </summary>
		public FICHAS_MEDICARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FICHAS_MEDICARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.PACIENTE != original.PACIENTE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsEDAD_PACIENTENull != original.IsEDAD_PACIENTENull) return true;
			if (!this.IsEDAD_PACIENTENull && !original.IsEDAD_PACIENTENull)
				if (this.EDAD_PACIENTE != original.EDAD_PACIENTE) return true;
			if (this.IsPESO_PACIENTENull != original.IsPESO_PACIENTENull) return true;
			if (!this.IsPESO_PACIENTENull && !original.IsPESO_PACIENTENull)
				if (this.PESO_PACIENTE != original.PESO_PACIENTE) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PACIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PACIENTE</c> column value.</value>
		public string PACIENTE
		{
			get { return _paciente; }
			set { _paciente = value; }
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
		/// Gets or sets the <c>EDAD_PACIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDAD_PACIENTE</c> column value.</value>
		public decimal EDAD_PACIENTE
		{
			get
			{
				if(IsEDAD_PACIENTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _edad_paciente;
			}
			set
			{
				_edad_pacienteNull = false;
				_edad_paciente = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EDAD_PACIENTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEDAD_PACIENTENull
		{
			get { return _edad_pacienteNull; }
			set { _edad_pacienteNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_PACIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_PACIENTE</c> column value.</value>
		public decimal PESO_PACIENTE
		{
			get
			{
				if(IsPESO_PACIENTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_paciente;
			}
			set
			{
				_peso_pacienteNull = false;
				_peso_paciente = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_PACIENTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_PACIENTENull
		{
			get { return _peso_pacienteNull; }
			set { _peso_pacienteNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@PACIENTE=");
			dynStr.Append(PACIENTE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@EDAD_PACIENTE=");
			dynStr.Append(IsEDAD_PACIENTENull ? (object)"<NULL>" : EDAD_PACIENTE);
			dynStr.Append("@CBA@PESO_PACIENTE=");
			dynStr.Append(IsPESO_PACIENTENull ? (object)"<NULL>" : PESO_PACIENTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			return dynStr.ToString();
		}
	} // End of FICHAS_MEDICARow_Base class
} // End of namespace
