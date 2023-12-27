// <fileinfo name="DIAS_SEMANARow_Base.cs">
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
	/// The base class for <see cref="DIAS_SEMANARow"/> that 
	/// represents a record in the <c>DIAS_SEMANA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DIAS_SEMANARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DIAS_SEMANARow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _abreviatura;
		private string _laborable;
		private System.DateTime _inicio_jornada;
		private bool _inicio_jornadaNull = true;
		private System.DateTime _fin_jornada;
		private bool _fin_jornadaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="DIAS_SEMANARow_Base"/> class.
		/// </summary>
		public DIAS_SEMANARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DIAS_SEMANARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.LABORABLE != original.LABORABLE) return true;
			if (this.IsINICIO_JORNADANull != original.IsINICIO_JORNADANull) return true;
			if (!this.IsINICIO_JORNADANull && !original.IsINICIO_JORNADANull)
				if (this.INICIO_JORNADA != original.INICIO_JORNADA) return true;
			if (this.IsFIN_JORNADANull != original.IsFIN_JORNADANull) return true;
			if (!this.IsFIN_JORNADANull && !original.IsFIN_JORNADANull)
				if (this.FIN_JORNADA != original.FIN_JORNADA) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LABORABLE</c> column value.
		/// </summary>
		/// <value>The <c>LABORABLE</c> column value.</value>
		public string LABORABLE
		{
			get { return _laborable; }
			set { _laborable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INICIO_JORNADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INICIO_JORNADA</c> column value.</value>
		public System.DateTime INICIO_JORNADA
		{
			get
			{
				if(IsINICIO_JORNADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inicio_jornada;
			}
			set
			{
				_inicio_jornadaNull = false;
				_inicio_jornada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INICIO_JORNADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINICIO_JORNADANull
		{
			get { return _inicio_jornadaNull; }
			set { _inicio_jornadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FIN_JORNADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FIN_JORNADA</c> column value.</value>
		public System.DateTime FIN_JORNADA
		{
			get
			{
				if(IsFIN_JORNADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fin_jornada;
			}
			set
			{
				_fin_jornadaNull = false;
				_fin_jornada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FIN_JORNADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFIN_JORNADANull
		{
			get { return _fin_jornadaNull; }
			set { _fin_jornadaNull = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@LABORABLE=");
			dynStr.Append(LABORABLE);
			dynStr.Append("@CBA@INICIO_JORNADA=");
			dynStr.Append(IsINICIO_JORNADANull ? (object)"<NULL>" : INICIO_JORNADA);
			dynStr.Append("@CBA@FIN_JORNADA=");
			dynStr.Append(IsFIN_JORNADANull ? (object)"<NULL>" : FIN_JORNADA);
			return dynStr.ToString();
		}
	} // End of DIAS_SEMANARow_Base class
} // End of namespace
