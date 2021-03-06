/*
 * Copyright (c) 2016 Thomas Pornin <pornin@bolet.org>
 *
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be 
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
 * BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
 * ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;

class TPointerXT : TPointerBase {

	internal string Name {
		get; private set;
	}

	internal Word Target {
		get; private set;
	}

	internal TPointerXT(string name)
	{
		this.Name = name;
		this.Target = null;
	}

	internal TPointerXT(Word target)
	{
		this.Name = target.Name;
		this.Target = target;
	}

	internal void Resolve(T0Comp ctx)
	{
		if (Target == null) {
			Target = ctx.Lookup(Name);
		}
	}

	internal override void Execute(T0Comp ctx, CPU cpu)
	{
		Resolve(ctx);
		Target.Run(cpu);
	}

	internal override string ToString(TValue vp)
	{
		return String.Format("<'{0}>", Name);
	}

	internal override bool Equals(TPointerBase tp)
	{
		TPointerXT tx = tp as TPointerXT;
		return tx != null && Name == tx.Name;
	}
}
