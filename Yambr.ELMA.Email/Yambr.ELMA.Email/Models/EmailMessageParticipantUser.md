<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>71e11768-05e2-4788-b93e-7440e72b32b5</Uid>
  <Name>EmailMessageParticipantUser</Name>
  <DisplayName>EmailMessageParticipantUser</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>2474afc5-cfb2-4c63-aa91-12c4087819d9</BaseClassUid>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>62ebc39c-714f-471e-955e-ec1c5717c279</Uid>
      <Name>User</Name>
      <DisplayName>User</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</SubTypeUid>
      <Settings xsi:type="EntityUserSettings">
        <FieldName>User</FieldName>
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
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>cbf3be84-d207-45d0-a26b-e60822be9197</Uid>
      <Name>Mailbox</Name>
      <DisplayName>Mailbox</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>06aeb963-e379-4fff-9951-de6bf6cb508f</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <FieldName>Mailbox</FieldName>
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
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>1</Order>
    </PropertyMetadata>
  </Properties>
  <PropertiesDiffContainer />
  <DefaultForms>
    <CreateUid>00000000-0000-0000-0000-000000000000</CreateUid>
    <EditUid>00000000-0000-0000-0000-000000000000</EditUid>
    <DisplayUid>00000000-0000-0000-0000-000000000000</DisplayUid>
    <ActionGuids />
    <FormSettings />
  </DefaultForms>
  <Forms />
  <FormTransformations />
  <FormViews />
  <TableViews>
    <TableView>
      <Uid>46ffb8e8-82cb-4e60-8719-303e04da6364</Uid>
      <ViewType>List</ViewType>
      <SortDescriptors />
      <GroupDescriptors />
    </TableView>
  </TableViews>
  <TitlePropertyUid>00000000-0000-0000-0000-000000000000</TitlePropertyUid>
  <Type>Interface</Type>
  <ImplementationUid>9d070869-4ac7-4d60-a952-b487652baa8f</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>EmailMessageParticipantUser</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ParentPropertyUid>00000000-0000-0000-0000-000000000000</ParentPropertyUid>
  <IsGroupPropertyUid>00000000-0000-0000-0000-000000000000</IsGroupPropertyUid>
  <Filter>
    <Uid>00000000-0000-0000-0000-000000000000</Uid>
    <BaseClassUid>00000000-0000-0000-0000-000000000000</BaseClassUid>
    <Properties />
    <PropertiesDiffContainer />
    <DefaultForms>
      <CreateUid>00000000-0000-0000-0000-000000000000</CreateUid>
      <EditUid>00000000-0000-0000-0000-000000000000</EditUid>
      <DisplayUid>00000000-0000-0000-0000-000000000000</DisplayUid>
      <ActionGuids />
      <FormSettings />
    </DefaultForms>
    <Forms />
    <FormTransformations />
    <FormViews />
    <TableViews />
    <TitlePropertyUid>00000000-0000-0000-0000-000000000000</TitlePropertyUid>
  </Filter>
  <ImplementedExtensionUids />
  <Actions>
    <Uid>00000000-0000-0000-0000-000000000000</Uid>
    <BaseTypeUid>00000000-0000-0000-0000-000000000000</BaseTypeUid>
    <Values />
  </Actions>
  <TableParts />
</Entity>