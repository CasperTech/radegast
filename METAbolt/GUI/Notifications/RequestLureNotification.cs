// 
// METABolt Metaverse Client, forked from RADISHGHAST
// Copyright (c) 2015, METABolt Development Team
// Copyright (c) 2009-2014, RADISHGHAST Development Team
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name "METAbolt", nor "RADISHGHAST", nor the names of its
//       contributors may be used to endorse or promote products derived from
//       this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// $Id$
//
using System;
using System.Windows.Forms;
using OpenMetaverse;

namespace METAbolt
{
    public partial class ntfRequestLure : Notification
    {
        private METAboltInstance instance;
        private InstantMessage msg;

        public ntfRequestLure(METAboltInstance instance, InstantMessage msg)
            : base(NotificationType.RequestLure)
        {
            InitializeComponent();
            this.instance = instance;
            this.msg = msg;

            txtHead.BackColor = instance.MainForm.NotificationBackground;
            txtHead.Text = String.Format("{0} is requesting to be teleported to your location.", msg.FromAgentName);
            txtMessage.BackColor = instance.MainForm.NotificationBackground;
            txtMessage.Text = msg.Message;
            btnTeleport.Focus();

            // Fire off event
            NotificationEventArgs args = new NotificationEventArgs(instance);
            args.Text = txtHead.Text + Environment.NewLine + txtMessage.Text;
            args.Buttons.Add(btnTeleport);
            args.Buttons.Add(btnCancel);
            FireNotificationCallback(args);
        }

        private void btnTeleport_Click(object sender, EventArgs e)
        {
            instance.Client.Self.SendTeleportLure(msg.FromAgentID, "Join me in " + instance.Client.Network.CurrentSim.Name + "!");
            instance.MainForm.RemoveNotification(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            instance.MainForm.RemoveNotification(this);
        }
    }
}
