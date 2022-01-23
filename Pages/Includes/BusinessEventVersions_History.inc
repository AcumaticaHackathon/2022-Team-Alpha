<px:PXTabItem Text="History">
                                <Template>
                                    <px:PXFormView Width="500" DataMember="BusinessEventVersions" Caption="Biz Event History" CaptionVisible="False" runat="server" ID="frmtBusEventHistory">
                                        <Template>
                                            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdBusEventVersions">
                                                <Levels>
                                                    <px:PXGridLevel DataMember="BusinessEventVersions">
                                                        <Columns>
                                                            <px:PXGridColumn DataField="Selected" Width="60"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="Version" Width="70"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="ActionName" Width="70"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="Description" Width="70"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="Name" Width="70"></px:PXGridColumn>
                                                            <px:PXGridColumn DataField="CreatedDateTime" Width="90"></px:PXGridColumn>
                                                        </Columns>
                                                    </px:PXGridLevel>
                                                </Levels>
                                                <ActionBar ActionsVisible="True">
                                                    <CustomItems>
                                                        <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                                                    </CustomItems>
                                                    <Actions>
                                                        <AddNew Enabled="False"></AddNew>
                                                    </Actions>
                                                    <Actions>
                                                        <Delete Enabled="False"></Delete>
                                                    </Actions>
                                                    <Actions>
                                                        <EditRecord Enabled="False"></EditRecord>
                                                    </Actions>
                                                    <Actions>
                                                        <Save Enabled="False"></Save>
                                                    </Actions>
                                                </ActionBar>
                                            </px:PXGrid>
                                        </Template>
                                    </px:PXFormView>
                                </Template>
                            </px:PXTabItem>