<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>a8ee5fd8-6f4e-4fe3-bd0b-063fe92694ab</Uid>
  <Name>EmailMessageParticipantContact</Name>
  <DisplayName>Участник письма - Контакт</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>2474afc5-cfb2-4c63-aa91-12c4087819d9</BaseClassUid>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>dac4aebc-48ea-401e-9a45-86139f08bec9</Uid>
      <Name>Contact</Name>
      <DisplayName>Contact</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>a9b1bc6a-3286-4264-81aa-02f6df73c080</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <FieldName>Contact</FieldName>
        <CascadeMode>SaveUpdate</CascadeMode>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
    </PropertyMetadata>
  </Properties>
  <TableViews>
    <TableView>
      <Uid>bc4af76d-9693-4b58-ac85-fdd3be8b4938</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <Type>Interface</Type>
  <ImplementationUid>99cb0b2d-1597-4d14-8fee-45e4c511647c</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>EmailMessageParticipantConta</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ShowInCatalogList>true</ShowInCatalogList>
  <Actions />
</Entity>